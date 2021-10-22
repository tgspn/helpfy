using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Helpfy
{
    public class DictionaryOnline
    {
        public async Task<IEnumerable<DictionaryOnlineResult>> MeaningsAsync(string verbete)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://api.dictionaryapi.dev/api/v2/entries/en/{verbete}");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<IEnumerable<DictionaryOnlineResult>>(content);
                else
                    throw new Exception(content);
            }

        }
    }
    public class DictionaryOnlineResult
    {
        public string word { get; set; }
        public string phonetic { get; set; }
        public Phonetic[] phonetics { get; set; }
        public string origin { get; set; }
        public Meaning[] meanings { get; set; }
    }

    public class Phonetic
    {
        public string text { get; set; }
        public string audio { get; set; }
    }

    public class Meaning
    {
        public string partOfSpeech { get; set; }
        public Definition[] definitions { get; set; }
    }

    public class Definition
    {
        public string definition { get; set; }
        public string example { get; set; }
        public string[] synonyms { get; set; }
        public object[] antonyms { get; set; }
    }

}
