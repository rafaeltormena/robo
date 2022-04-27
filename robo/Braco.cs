namespace robo
{
    
    public class Braco
    {
        public enum ECotovelo
        {
            EmRepouso = 1,
            LevementeContraido = 2,
            Contraido = 3,
            FortementeContraido = 4
        }

        public enum EPulso
        {
            RotacaoNeg90 = 1,
            RotacaoNeg45 = 2,
            EmRepouso = 3,
            Rotacao45 = 4,
            Rotacao90 = 5,
            Rotacao135 = 6,
            Rotacao180 = 7
        }

        public int Cotovelo { get; set; }
        public int Pulso { get; set; }
    }
}
