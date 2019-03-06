namespace CEA.RestClient.ApiModels
{
    public class Audio
    {
        public string AudioID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Favorite { get; set; }
        public bool? Shared { get; set; }
        public int? Length { get; set; }

        public string Created { get; set; }
        public string LastUsed { get; set; }

        public bool TextToSpeech { get; set; }
        public string Text { get; set; }
        public string Voice { get; set; }
    }
}
