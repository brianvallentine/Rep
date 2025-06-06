using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBGE0531_LK_GE0531 : VarBasis
    {
        /*"    05  LK-GE0531-CPF-CNPJ          PIC  9(011) VALUE 0.*/
        public IntBasis LK_GE0531_CPF_CNPJ { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
        /*"    05  LK-GE0531-SEQ-REGISTRO      PIC  9(009) VALUE 0.*/
        public IntBasis LK_GE0531_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"    05  LK-GE0531-NOM-SEGURADO      PIC  X(070) VALUE SPACES.*/
        public StringBasis LK_GE0531_NOM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"    05  LK-GE0531-NUM-RAMO-EMISSOR  PIC  9(004) VALUE 0.*/
        public IntBasis LK_GE0531_NUM_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    05  LK-GE0531-COD-PRODUTO       PIC  9(009) VALUE 0.*/
        public IntBasis LK_GE0531_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"    05  LK-GE0531-COD-FONTE         PIC  9(004) VALUE 0.*/
        public IntBasis LK_GE0531_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    05  LK-GE0531-NUM-PROPOSTA      PIC  9(009) VALUE 0.*/
        public IntBasis LK_GE0531_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"    05  LK-GE0531-NUM-CERTIFIC-EXT  PIC  9(018) VALUE 0.*/
        public IntBasis LK_GE0531_NUM_CERTIFIC_EXT { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
        /*"    05  LK-GE0531-DADOS-LOG.*/
        public LBGE0531_LK_GE0531_DADOS_LOG LK_GE0531_DADOS_LOG { get; set; } = new LBGE0531_LK_GE0531_DADOS_LOG();

        public LBGE0531_LK_GE0531_GERAL LK_GE0531_GERAL { get; set; } = new LBGE0531_LK_GE0531_GERAL();

    }
}