namespace robo
{
    public class Cabeca
    {
        public enum EInclinacao
        {
            ParaCima = 1,
            EmRepouso = 2,
            ParaBaixo = 3
        }

        public enum ERotacao
        {
            RotacaoNeg90 = 1,
            RotacaoNeg45 = 2,
            EmRepouso = 3,
            Rotacao45 = 4,
            Rotacao90 = 5
        }

        public int Inclinacao { get; set; }
        public int Rotacao { get; set; }
    }
}
