using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB038_INCLUI_TERMO_ADESAO_DB_INSERT_1_Insert1 : QueryBasis<DB038_INCLUI_TERMO_ADESAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.TERMO_ADESAO
            (NUM_TERMO ,
            COD_SUBGRUPO ,
            DATA_ADESAO ,
            COD_AGENCIA_OP ,
            NUM_MATRICULA_VEN ,
            CODPDTVEN ,
            PCCOMVEN ,
            PCADIANTVEN ,
            COD_AGENCIA_VEN ,
            OPERACAO_CONTA_VEN,
            NUM_CONTA_VEN ,
            DIG_CONTA_VEN ,
            NUM_MATRICULA_GER ,
            CODPDTGER ,
            PCCOMGER ,
            COD_AGENCIA_GER ,
            OPERACAO_CONTA_GER,
            NUM_CONTA_GER ,
            DIG_CONTA_GER ,
            NUM_MATRICULA_SUR ,
            CODPDTSUR ,
            PCCOMSUR ,
            NUM_MATRICULA_GCO ,
            CODPDTGCO ,
            PCCOMGCO ,
            MODALIDADE_CAPITAL,
            TIPO_PLANO ,
            IND_PLANO_ASSOCIAD,
            COD_PLANO_VGAPC ,
            COD_PLANO_APC ,
            VAL_CONTRATADO ,
            VAL_COMISSAO_ADIAN,
            QUANT_VIDAS ,
            TIPO_COBERTURA ,
            PERI_PAGAMENTO ,
            TIPO_CORRECAO ,
            PERIODO_CORRECAO ,
            COD_MOEDA_IMP ,
            COD_MOEDA_PRM ,
            COD_CLIENTE ,
            OCORR_ENDERECO ,
            COD_CORRETOR ,
            PCCOMCOR ,
            COD_ADMINISTRADOR ,
            PCCOMADM ,
            COD_USUARIO ,
            DATA_INCLUSAO ,
            SITUACAO ,
            TIMESTAMP ,
            NUM_PROPOSTA ,
            NUM_RCAP ,
            DATA_RCAP ,
            VAL_RCAP ,
            NUM_APOLICE )
            VALUES
            (:TERMOADE-NUM-TERMO ,
            :TERMOADE-COD-SUBGRUPO ,
            :TERMOADE-DATA-ADESAO ,
            :TERMOADE-COD-AGENCIA-OP ,
            :TERMOADE-NUM-MATRICULA-VEN ,
            :TERMOADE-CODPDTVEN ,
            :TERMOADE-PCCOMVEN ,
            :TERMOADE-PCADIANTVEN ,
            :TERMOADE-COD-AGENCIA-VEN ,
            :TERMOADE-OPERACAO-CONTA-VEN,
            :TERMOADE-NUM-CONTA-VEN ,
            :TERMOADE-DIG-CONTA-VEN ,
            :TERMOADE-NUM-MATRICULA-GER ,
            :TERMOADE-CODPDTGER ,
            :TERMOADE-PCCOMGER ,
            :TERMOADE-COD-AGENCIA-GER ,
            :TERMOADE-OPERACAO-CONTA-GER,
            :TERMOADE-NUM-CONTA-GER ,
            :TERMOADE-DIG-CONTA-GER ,
            :TERMOADE-NUM-MATRICULA-SUR ,
            :TERMOADE-CODPDTSUR ,
            :TERMOADE-PCCOMSUR ,
            :TERMOADE-NUM-MATRICULA-GCO ,
            :TERMOADE-CODPDTGCO ,
            :TERMOADE-PCCOMGCO ,
            :TERMOADE-MODALIDADE-CAPITAL,
            :TERMOADE-TIPO-PLANO ,
            :TERMOADE-IND-PLANO-ASSOCIAD,
            :TERMOADE-COD-PLANO-VGAPC ,
            :TERMOADE-COD-PLANO-APC ,
            :TERMOADE-VAL-CONTRATADO ,
            :TERMOADE-VAL-COMISSAO-ADIAN,
            :TERMOADE-QUANT-VIDAS ,
            :TERMOADE-TIPO-COBERTURA ,
            :TERMOADE-PERI-PAGAMENTO ,
            :TERMOADE-TIPO-CORRECAO ,
            :TERMOADE-PERIODO-CORRECAO ,
            :TERMOADE-COD-MOEDA-IMP ,
            :TERMOADE-COD-MOEDA-PRM ,
            :TERMOADE-COD-CLIENTE ,
            :TERMOADE-OCORR-ENDERECO ,
            :TERMOADE-COD-CORRETOR ,
            :TERMOADE-PCCOMCOR ,
            :TERMOADE-COD-ADMINISTRADOR ,
            :TERMOADE-PCCOMADM ,
            :TERMOADE-COD-USUARIO ,
            :TERMOADE-DATA-INCLUSAO ,
            :TERMOADE-SITUACAO ,
            CURRENT TIMESTAMP ,
            :TERMOADE-NUM-PROPOSTA ,
            :TERMOADE-NUM-RCAP ,
            :TERMOADE-DATA-RCAP ,
            :TERMOADE-VAL-RCAP ,
            :TERMOADE-NUM-APOLICE )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.TERMO_ADESAO (NUM_TERMO , COD_SUBGRUPO , DATA_ADESAO , COD_AGENCIA_OP , NUM_MATRICULA_VEN , CODPDTVEN , PCCOMVEN , PCADIANTVEN , COD_AGENCIA_VEN , OPERACAO_CONTA_VEN, NUM_CONTA_VEN , DIG_CONTA_VEN , NUM_MATRICULA_GER , CODPDTGER , PCCOMGER , COD_AGENCIA_GER , OPERACAO_CONTA_GER, NUM_CONTA_GER , DIG_CONTA_GER , NUM_MATRICULA_SUR , CODPDTSUR , PCCOMSUR , NUM_MATRICULA_GCO , CODPDTGCO , PCCOMGCO , MODALIDADE_CAPITAL, TIPO_PLANO , IND_PLANO_ASSOCIAD, COD_PLANO_VGAPC , COD_PLANO_APC , VAL_CONTRATADO , VAL_COMISSAO_ADIAN, QUANT_VIDAS , TIPO_COBERTURA , PERI_PAGAMENTO , TIPO_CORRECAO , PERIODO_CORRECAO , COD_MOEDA_IMP , COD_MOEDA_PRM , COD_CLIENTE , OCORR_ENDERECO , COD_CORRETOR , PCCOMCOR , COD_ADMINISTRADOR , PCCOMADM , COD_USUARIO , DATA_INCLUSAO , SITUACAO , TIMESTAMP , NUM_PROPOSTA , NUM_RCAP , DATA_RCAP , VAL_RCAP , NUM_APOLICE ) VALUES ({FieldThreatment(this.TERMOADE_NUM_TERMO)} , {FieldThreatment(this.TERMOADE_COD_SUBGRUPO)} , {FieldThreatment(this.TERMOADE_DATA_ADESAO)} , {FieldThreatment(this.TERMOADE_COD_AGENCIA_OP)} , {FieldThreatment(this.TERMOADE_NUM_MATRICULA_VEN)} , {FieldThreatment(this.TERMOADE_CODPDTVEN)} , {FieldThreatment(this.TERMOADE_PCCOMVEN)} , {FieldThreatment(this.TERMOADE_PCADIANTVEN)} , {FieldThreatment(this.TERMOADE_COD_AGENCIA_VEN)} , {FieldThreatment(this.TERMOADE_OPERACAO_CONTA_VEN)}, {FieldThreatment(this.TERMOADE_NUM_CONTA_VEN)} , {FieldThreatment(this.TERMOADE_DIG_CONTA_VEN)} , {FieldThreatment(this.TERMOADE_NUM_MATRICULA_GER)} , {FieldThreatment(this.TERMOADE_CODPDTGER)} , {FieldThreatment(this.TERMOADE_PCCOMGER)} , {FieldThreatment(this.TERMOADE_COD_AGENCIA_GER)} , {FieldThreatment(this.TERMOADE_OPERACAO_CONTA_GER)}, {FieldThreatment(this.TERMOADE_NUM_CONTA_GER)} , {FieldThreatment(this.TERMOADE_DIG_CONTA_GER)} , {FieldThreatment(this.TERMOADE_NUM_MATRICULA_SUR)} , {FieldThreatment(this.TERMOADE_CODPDTSUR)} , {FieldThreatment(this.TERMOADE_PCCOMSUR)} , {FieldThreatment(this.TERMOADE_NUM_MATRICULA_GCO)} , {FieldThreatment(this.TERMOADE_CODPDTGCO)} , {FieldThreatment(this.TERMOADE_PCCOMGCO)} , {FieldThreatment(this.TERMOADE_MODALIDADE_CAPITAL)}, {FieldThreatment(this.TERMOADE_TIPO_PLANO)} , {FieldThreatment(this.TERMOADE_IND_PLANO_ASSOCIAD)}, {FieldThreatment(this.TERMOADE_COD_PLANO_VGAPC)} , {FieldThreatment(this.TERMOADE_COD_PLANO_APC)} , {FieldThreatment(this.TERMOADE_VAL_CONTRATADO)} , {FieldThreatment(this.TERMOADE_VAL_COMISSAO_ADIAN)}, {FieldThreatment(this.TERMOADE_QUANT_VIDAS)} , {FieldThreatment(this.TERMOADE_TIPO_COBERTURA)} , {FieldThreatment(this.TERMOADE_PERI_PAGAMENTO)} , {FieldThreatment(this.TERMOADE_TIPO_CORRECAO)} , {FieldThreatment(this.TERMOADE_PERIODO_CORRECAO)} , {FieldThreatment(this.TERMOADE_COD_MOEDA_IMP)} , {FieldThreatment(this.TERMOADE_COD_MOEDA_PRM)} , {FieldThreatment(this.TERMOADE_COD_CLIENTE)} , {FieldThreatment(this.TERMOADE_OCORR_ENDERECO)} , {FieldThreatment(this.TERMOADE_COD_CORRETOR)} , {FieldThreatment(this.TERMOADE_PCCOMCOR)} , {FieldThreatment(this.TERMOADE_COD_ADMINISTRADOR)} , {FieldThreatment(this.TERMOADE_PCCOMADM)} , {FieldThreatment(this.TERMOADE_COD_USUARIO)} , {FieldThreatment(this.TERMOADE_DATA_INCLUSAO)} , {FieldThreatment(this.TERMOADE_SITUACAO)} , CURRENT TIMESTAMP , {FieldThreatment(this.TERMOADE_NUM_PROPOSTA)} , {FieldThreatment(this.TERMOADE_NUM_RCAP)} , {FieldThreatment(this.TERMOADE_DATA_RCAP)} , {FieldThreatment(this.TERMOADE_VAL_RCAP)} , {FieldThreatment(this.TERMOADE_NUM_APOLICE)} )";

            return query;
        }
        public string TERMOADE_NUM_TERMO { get; set; }
        public string TERMOADE_COD_SUBGRUPO { get; set; }
        public string TERMOADE_DATA_ADESAO { get; set; }
        public string TERMOADE_COD_AGENCIA_OP { get; set; }
        public string TERMOADE_NUM_MATRICULA_VEN { get; set; }
        public string TERMOADE_CODPDTVEN { get; set; }
        public string TERMOADE_PCCOMVEN { get; set; }
        public string TERMOADE_PCADIANTVEN { get; set; }
        public string TERMOADE_COD_AGENCIA_VEN { get; set; }
        public string TERMOADE_OPERACAO_CONTA_VEN { get; set; }
        public string TERMOADE_NUM_CONTA_VEN { get; set; }
        public string TERMOADE_DIG_CONTA_VEN { get; set; }
        public string TERMOADE_NUM_MATRICULA_GER { get; set; }
        public string TERMOADE_CODPDTGER { get; set; }
        public string TERMOADE_PCCOMGER { get; set; }
        public string TERMOADE_COD_AGENCIA_GER { get; set; }
        public string TERMOADE_OPERACAO_CONTA_GER { get; set; }
        public string TERMOADE_NUM_CONTA_GER { get; set; }
        public string TERMOADE_DIG_CONTA_GER { get; set; }
        public string TERMOADE_NUM_MATRICULA_SUR { get; set; }
        public string TERMOADE_CODPDTSUR { get; set; }
        public string TERMOADE_PCCOMSUR { get; set; }
        public string TERMOADE_NUM_MATRICULA_GCO { get; set; }
        public string TERMOADE_CODPDTGCO { get; set; }
        public string TERMOADE_PCCOMGCO { get; set; }
        public string TERMOADE_MODALIDADE_CAPITAL { get; set; }
        public string TERMOADE_TIPO_PLANO { get; set; }
        public string TERMOADE_IND_PLANO_ASSOCIAD { get; set; }
        public string TERMOADE_COD_PLANO_VGAPC { get; set; }
        public string TERMOADE_COD_PLANO_APC { get; set; }
        public string TERMOADE_VAL_CONTRATADO { get; set; }
        public string TERMOADE_VAL_COMISSAO_ADIAN { get; set; }
        public string TERMOADE_QUANT_VIDAS { get; set; }
        public string TERMOADE_TIPO_COBERTURA { get; set; }
        public string TERMOADE_PERI_PAGAMENTO { get; set; }
        public string TERMOADE_TIPO_CORRECAO { get; set; }
        public string TERMOADE_PERIODO_CORRECAO { get; set; }
        public string TERMOADE_COD_MOEDA_IMP { get; set; }
        public string TERMOADE_COD_MOEDA_PRM { get; set; }
        public string TERMOADE_COD_CLIENTE { get; set; }
        public string TERMOADE_OCORR_ENDERECO { get; set; }
        public string TERMOADE_COD_CORRETOR { get; set; }
        public string TERMOADE_PCCOMCOR { get; set; }
        public string TERMOADE_COD_ADMINISTRADOR { get; set; }
        public string TERMOADE_PCCOMADM { get; set; }
        public string TERMOADE_COD_USUARIO { get; set; }
        public string TERMOADE_DATA_INCLUSAO { get; set; }
        public string TERMOADE_SITUACAO { get; set; }
        public string TERMOADE_NUM_PROPOSTA { get; set; }
        public string TERMOADE_NUM_RCAP { get; set; }
        public string TERMOADE_DATA_RCAP { get; set; }
        public string TERMOADE_VAL_RCAP { get; set; }
        public string TERMOADE_NUM_APOLICE { get; set; }

        public static void Execute(DB038_INCLUI_TERMO_ADESAO_DB_INSERT_1_Insert1 dB038_INCLUI_TERMO_ADESAO_DB_INSERT_1_Insert1)
        {
            var ths = dB038_INCLUI_TERMO_ADESAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB038_INCLUI_TERMO_ADESAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}