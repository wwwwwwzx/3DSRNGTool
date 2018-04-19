using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Pk3DSRNGTool.Properties;

namespace Pk3DSRNGTool
{
    public static class Translator
    {
        private static readonly Dictionary<string, TranslationContext> Context = new Dictionary<string, TranslationContext>();
        internal static void TranslateInterface(this Control form, string lang = null) => TranslateForm(form, GetContext(lang ?? Settings.Default.Language));

        private static string GetTranslationFileNameExternal(string lang) => $"lang_{lang}.txt";
        private static TranslationContext GetContext(string lang)
        {
            if (Context.TryGetValue(lang, out var context))
                return context;

            var lines = GetTranslationFile(lang);
            Context.Add(lang, context = new TranslationContext(lines));
            return context;
        }

        private static void TranslateForm(Control form, TranslationContext context)
        {
            form.SuspendLayout();
            var formname = form.Name;
            // Translate Title
            form.Text = context.GetTranslatedText(formname, form.Text);
            var translatable = GetTranslatableControls(form);
            foreach (var c in translatable)
            {
                if (c is Control r)
                    r.Text = context.GetTranslatedText($"{formname}.{r.Name}", r.Text);
                else if (c is ToolStripItem t)
                    t.Text = context.GetTranslatedText($"{formname}.{t.Name}", t.Text);
                else if (c is DataGridViewColumn d)
                    d.HeaderText = context.GetTranslatedText($"{formname}.{d.Name}", d.HeaderText);
            }
            form.ResumeLayout();
        }

        private static IEnumerable<string> GetTranslationFile(string lang)
        {
            var ExternalFile = GetTranslationFileNameExternal(lang);
            // Check to see if a the translation file exists in the same folder as the executable
            if (File.Exists(ExternalFile))
            {
                try { return File.ReadAllLines(ExternalFile); }
                catch { /* In use? Just return the internal resource. */ }
            }
            object txt = Resources.ResourceManager.GetObject($"lang_{lang}");
            if (txt == null) return null;
            return ((string)txt).Split(new[] { "\n" }, StringSplitOptions.None)
                                .Select(i => i.Trim())
                                .Where(i => !string.IsNullOrEmpty(i)).ToArray();
        }

        private static IEnumerable<object> GetTranslatableControls(Control f)
        {
            foreach (var z in f.GetChildrenOfType<Control>())
            {
                switch (z)
                {
                    case ToolStrip menu:
                        foreach (var obj in GetToolStripMenuItems(menu))
                            yield return obj;
                        break;

                    case DataGridView dgv:
                        foreach (var col in dgv.Columns.OfType<DataGridViewColumn>())
                            yield return col;
                        goto default;

                    default:
                        if (string.IsNullOrWhiteSpace(z.Name) || z.Name.Contains("label"))
                            break;

                        if (z.ContextMenuStrip != null) // control has attached menustrip
                            foreach (var obj in GetToolStripMenuItems(z.ContextMenuStrip))
                                yield return obj;

                        if (z is TextBox || z is MaskedTextBox || z is LinkLabel
                            || z is NumericUpDown || z is ComboBox)
                            break; // undesirable to modify, ignore

                        yield return z;
                        break;
                }
            }
        }
        private static IEnumerable<T> GetChildrenOfType<T>(this Control control) where T : class
        {
            foreach (Control child in control.Controls)
            {
                var childOfT = child as T;
                if (childOfT != null)
                    yield return childOfT;

                if (!child.HasChildren) continue;
                foreach (var descendant in GetChildrenOfType<T>(child))
                    yield return descendant;
            }
        }
        private static IEnumerable<object> GetToolStripMenuItems(ToolStrip menu)
        {
            foreach (var i in menu.Items.OfType<ToolStripMenuItem>())
            {
                if (!string.IsNullOrWhiteSpace(i.Text))
                    yield return i;
                foreach (var sub in GetToolsStripDropDownItems(i).Where(z => !string.IsNullOrWhiteSpace(z.Text)))
                    yield return sub;
            }
        }
        private static IEnumerable<ToolStripMenuItem> GetToolsStripDropDownItems(ToolStripDropDownItem item)
        {
            foreach (var dropDownItem in item.DropDownItems.OfType<ToolStripMenuItem>())
            {
                yield return dropDownItem;
                if (!dropDownItem.HasDropDownItems) continue;
                foreach (ToolStripMenuItem subItem in GetToolsStripDropDownItems(dropDownItem))
                    yield return subItem;
            }
        }

#if DEBUG
        private static readonly string[] Languages = StringItem.langlist.Skip(1).ToArray();
        private const string DefaultLanguage = "en";
        public static void UpdateTranslations(bool CheckUnUsed = false)
        {
            TranslationContext.AddNew = true;
            UpdateAll(DefaultLanguage, Languages);
            if (CheckUnUsed)
            {
                TranslationContext.RemoveUsedKeys = true;
                UpdateAll(DefaultLanguage, Languages);
            }
            DumpAll(); // dump current to file
        }

        public static void UpdateAll(string baseLanguage, IEnumerable<string> others)
        {
            var basecontext = GetContext(baseLanguage);
            foreach (var lang in others)
            {
                var c = GetContext(lang);
                c.UpdateFrom(basecontext);
            }
        }

        public static void DumpAll()
        {
            var results = Context.Select(z => new { Lang = z.Key, Lines = z.Value.Write() });
            foreach (var c in results)
                File.WriteAllLines(GetTranslationFileNameExternal(c.Lang), c.Lines);
        }
#endif
    }

    public class TranslationContext
    {
        public const char Separator = '=';
        public static bool AddNew;
        public static bool RemoveUsedKeys;
        private readonly Dictionary<string, string> Translation = new Dictionary<string, string>();
        public TranslationContext(IEnumerable<string> content)
        {
            var entries = content.Select(z => z.Split(new[] { Separator }, 2));
            foreach (var r in entries.Where(z => !Translation.ContainsKey(z[0])))
                Translation.Add(r[0], r[1]);
        }

        public string GetTranslatedText(string val, string fallback)
        {
            if (RemoveUsedKeys)
                Translation.Remove(val);

            if (Translation.TryGetValue(val, out var translated))
                return translated;

            if (val.Contains(".") && Translation.TryGetValue(val.Split('.').Last(), out var controlname))
                return controlname;

            if (fallback != null && AddNew)
                Translation.Add(val, fallback);
            return fallback;
        }

#if DEBUG
        public static readonly string[] banlist =
        {
            "MainForm.B_AddProfile",
            "MainForm.B_IVInput",
            "MainForm.dgv_frame0",
            "MainForm.dgv_Lv",
            "MainForm.dgv_pid",
            "MainForm.dgv_SID",
            "MainForm.dgv_TID",
            "MainForm.dgv_TSV",
            "MainForm.dgv_wurmpleevo",
            "MainForm.Filter_FullID",
            "MainForm.Filter_G7TID",
            "MainForm.Filter_SID",
            "MainForm.Filter_TID",
            "MainForm.Filter_TSV",
            "MainForm.GB_RNGGEN7ID",
            "MainForm.L_EC",
            "MainForm.L_Event_TSV",
            "MainForm.L_PID",
            "MainForm.L_SID",
            "MainForm.L_SOSRNGSeed",
            "MainForm.L_TID",
            "MainForm.M_KeyBV",
            "MainForm.RNGPanel",
            "MiscRNGTool.TTT",
            "MiscRNGTool.dgv_randn",
            "Gen6MTSeedFinder.dgv_Seed_seed",
            "Gen6MTSeedFinder.L_Progress6",
            "Gen7EggSeedFinder.L_Progress7",
            "TinyTimelineTool.boost",
            "TinyTimelineTool.dgv_bgm",
            "TinyTimelineTool.tiny_rand100",
            "NTRHelper.B_A",
            "NTRHelper.JPN",
            "NTRHelper.L_NTRLog",
        };

        public IEnumerable<string> Write()
        {
            return Translation.Where(z => !banlist.Any(z.Key.Contains))
                              .Select(z => $"{z.Key}{Separator}{z.Value}")
                              .OrderBy(z => z.Contains(".") && z.IndexOf('.') < z.IndexOf('='))
                              .ThenBy(z => z);
        }

        public void UpdateFrom(TranslationContext other)
        {
            foreach (var kvp in other.Translation)
                GetTranslatedText(kvp.Key, kvp.Value);
        }
#endif
    }
}