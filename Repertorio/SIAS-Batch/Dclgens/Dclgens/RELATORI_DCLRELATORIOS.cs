using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class RELATORI_DCLRELATORIOS : VarBasis
    {
        /*"    10 RELATORI-COD-USUARIO  PIC X(8).*/
        public StringBasis RELATORI_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 RELATORI-DATA-SOLICITACAO  PIC X(10).*/
        public StringBasis RELATORI_DATA_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RELATORI-IDE-SISTEMA  PIC X(2).*/
        public StringBasis RELATORI_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 RELATORI-COD-RELATORIO  PIC X(8).*/
        public StringBasis RELATORI_COD_RELATORIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 RELATORI-NUM-COPIAS  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_NUM_COPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-QUANTIDADE  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-PERI-INICIAL  PIC X(10).*/
        public StringBasis RELATORI_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RELATORI-PERI-FINAL  PIC X(10).*/
        public StringBasis RELATORI_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RELATORI-DATA-REFERENCIA  PIC X(10).*/
        public StringBasis RELATORI_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RELATORI-MES-REFERENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_MES_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-ANO-REFERENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-ORGAO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_ORGAO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-COD-PRODUTOR  PIC S9(9) USAGE COMP.*/
        public IntBasis RELATORI_COD_PRODUTOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RELATORI-RAMO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-COD-MODALIDADE  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-COD-CONGENERE  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis RELATORI_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 RELATORI-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis RELATORI_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RELATORI-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis RELATORI_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 RELATORI-NUM-TITULO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis RELATORI_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 RELATORI-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-COD-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-NUM-APOL-LIDER  PIC X(15).*/
        public StringBasis RELATORI_NUM_APOL_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 RELATORI-ENDOS-LIDER  PIC X(15).*/
        public StringBasis RELATORI_ENDOS_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 RELATORI-NUM-PARC-LIDER  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_NUM_PARC_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-NUM-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis RELATORI_NUM_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 RELATORI-NUM-SINI-LIDER  PIC X(15).*/
        public StringBasis RELATORI_NUM_SINI_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 RELATORI-NUM-ORDEM   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis RELATORI_NUM_ORDEM { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 RELATORI-COD-MOEDA   PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-TIPO-CORRECAO  PIC X(1).*/
        public StringBasis RELATORI_TIPO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RELATORI-SIT-REGISTRO  PIC X(1).*/
        public StringBasis RELATORI_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RELATORI-IND-PREV-DEFINIT  PIC X(1).*/
        public StringBasis RELATORI_IND_PREV_DEFINIT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RELATORI-IND-ANAL-RESUMO  PIC X(1).*/
        public StringBasis RELATORI_IND_ANAL_RESUMO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RELATORI-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis RELATORI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RELATORI-PERI-RENOVACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis RELATORI_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELATORI-PCT-AUMENTO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis RELATORI_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 RELATORI-TIMESTAMP   PIC X(26).*/
        public StringBasis RELATORI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}