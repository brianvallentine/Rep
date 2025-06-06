using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 : QueryBasis<R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NUM_APOLICE
            ,B.NUM_ENDOSSO
            ,B.NUM_PARCELA
            ,B.DAC_PARCELA
            ,B.COD_OPERACAO
            ,B.OCORR_HISTORICO
            ,B.PRM_TARIFARIO
            ,B.VAL_DESCONTO
            ,B.PRM_LIQUIDO
            ,B.ADICIONAL_FRACIO
            ,B.VAL_CUSTO_EMISSAO
            ,B.VAL_IOCC
            ,B.PRM_TOTAL
            ,B.VAL_OPERACAO
            ,B.DATA_VENCIMENTO
            ,B.BCO_COBRANCA
            ,B.AGE_COBRANCA
            ,B.NUM_AVISO_CREDITO
            ,B.SIT_CONTABIL
            ,B.DATA_QUITACAO
            ,B.COD_EMPRESA
            ,C.ORGAO_EMISSOR
            ,C.RAMO_EMISSOR
            INTO :PARCEHIS-NUM-APOLICE
            ,:PARCEHIS-NUM-ENDOSSO
            ,:PARCEHIS-NUM-PARCELA
            ,:PARCEHIS-DAC-PARCELA
            ,:PARCEHIS-COD-OPERACAO
            ,:PARCEHIS-OCORR-HISTORICO
            ,:PARCEHIS-PRM-TARIFARIO
            ,:PARCEHIS-VAL-DESCONTO
            ,:PARCEHIS-PRM-LIQUIDO
            ,:PARCEHIS-ADICIONAL-FRACIO
            ,:PARCEHIS-VAL-CUSTO-EMISSAO
            ,:PARCEHIS-VAL-IOCC
            ,:PARCEHIS-PRM-TOTAL
            ,:PARCEHIS-VAL-OPERACAO
            ,:PARCEHIS-DATA-VENCIMENTO
            ,:PARCEHIS-BCO-COBRANCA
            ,:PARCEHIS-AGE-COBRANCA
            ,:PARCEHIS-NUM-AVISO-CREDITO
            ,:PARCEHIS-SIT-CONTABIL
            ,:PARCEHIS-DATA-QUITACAO:VIND-NULL01
            ,:PARCEHIS-COD-EMPRESA:VIND-NULL02
            ,:APOLICES-ORGAO-EMISSOR
            ,:APOLICES-RAMO-EMISSOR
            FROM SEGUROS.APOLICES C
            ,SEGUROS.PARCELAS A
            ,SEGUROS.PARCELA_HISTORICO B
            ,SEGUROS.ENDOSSOS D
            WHERE C.NUM_APOLICE = :BILHETE-NUM-APOLICE
            AND D.NUM_APOLICE = C.NUM_APOLICE
            AND D.TIPO_ENDOSSO IN ( '0' , '1' )
            AND D.NUM_APOLICE = A.NUM_APOLICE
            AND D.NUM_ENDOSSO = A.NUM_ENDOSSO
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
            AND B.NUM_PARCELA = A.NUM_PARCELA
            AND B.OCORR_HISTORICO = A.OCORR_HISTORICO
            AND B.COD_OPERACAO BETWEEN 200 AND 299
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.NUM_APOLICE
											,B.NUM_ENDOSSO
											,B.NUM_PARCELA
											,B.DAC_PARCELA
											,B.COD_OPERACAO
											,B.OCORR_HISTORICO
											,B.PRM_TARIFARIO
											,B.VAL_DESCONTO
											,B.PRM_LIQUIDO
											,B.ADICIONAL_FRACIO
											,B.VAL_CUSTO_EMISSAO
											,B.VAL_IOCC
											,B.PRM_TOTAL
											,B.VAL_OPERACAO
											,B.DATA_VENCIMENTO
											,B.BCO_COBRANCA
											,B.AGE_COBRANCA
											,B.NUM_AVISO_CREDITO
											,B.SIT_CONTABIL
											,B.DATA_QUITACAO
											,B.COD_EMPRESA
											,C.ORGAO_EMISSOR
											,C.RAMO_EMISSOR
											FROM SEGUROS.APOLICES C
											,SEGUROS.PARCELAS A
											,SEGUROS.PARCELA_HISTORICO B
											,SEGUROS.ENDOSSOS D
											WHERE C.NUM_APOLICE = '{this.BILHETE_NUM_APOLICE}'
											AND D.NUM_APOLICE = C.NUM_APOLICE
											AND D.TIPO_ENDOSSO IN ( '0' 
							, '1' )
											AND D.NUM_APOLICE = A.NUM_APOLICE
											AND D.NUM_ENDOSSO = A.NUM_ENDOSSO
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
											AND B.NUM_PARCELA = A.NUM_PARCELA
											AND B.OCORR_HISTORICO = A.OCORR_HISTORICO
											AND B.COD_OPERACAO BETWEEN 200 AND 299
											WITH UR";

            return query;
        }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }
        public string PARCEHIS_DAC_PARCELA { get; set; }
        public string PARCEHIS_COD_OPERACAO { get; set; }
        public string PARCEHIS_OCORR_HISTORICO { get; set; }
        public string PARCEHIS_PRM_TARIFARIO { get; set; }
        public string PARCEHIS_VAL_DESCONTO { get; set; }
        public string PARCEHIS_PRM_LIQUIDO { get; set; }
        public string PARCEHIS_ADICIONAL_FRACIO { get; set; }
        public string PARCEHIS_VAL_CUSTO_EMISSAO { get; set; }
        public string PARCEHIS_VAL_IOCC { get; set; }
        public string PARCEHIS_PRM_TOTAL { get; set; }
        public string PARCEHIS_VAL_OPERACAO { get; set; }
        public string PARCEHIS_DATA_VENCIMENTO { get; set; }
        public string PARCEHIS_BCO_COBRANCA { get; set; }
        public string PARCEHIS_AGE_COBRANCA { get; set; }
        public string PARCEHIS_NUM_AVISO_CREDITO { get; set; }
        public string PARCEHIS_SIT_CONTABIL { get; set; }
        public string PARCEHIS_DATA_QUITACAO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string PARCEHIS_COD_EMPRESA { get; set; }
        public string VIND_NULL02 { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }

        public static R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 Execute(R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 r0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1)
        {
            var ths = r0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0370_00_SELECT_PARCEHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PARCEHIS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.PARCEHIS_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PARCEHIS_DAC_PARCELA = result[i++].Value?.ToString();
            dta.PARCEHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.PARCEHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.PARCEHIS_PRM_TARIFARIO = result[i++].Value?.ToString();
            dta.PARCEHIS_VAL_DESCONTO = result[i++].Value?.ToString();
            dta.PARCEHIS_PRM_LIQUIDO = result[i++].Value?.ToString();
            dta.PARCEHIS_ADICIONAL_FRACIO = result[i++].Value?.ToString();
            dta.PARCEHIS_VAL_CUSTO_EMISSAO = result[i++].Value?.ToString();
            dta.PARCEHIS_VAL_IOCC = result[i++].Value?.ToString();
            dta.PARCEHIS_PRM_TOTAL = result[i++].Value?.ToString();
            dta.PARCEHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.PARCEHIS_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.PARCEHIS_BCO_COBRANCA = result[i++].Value?.ToString();
            dta.PARCEHIS_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.PARCEHIS_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.PARCEHIS_SIT_CONTABIL = result[i++].Value?.ToString();
            dta.PARCEHIS_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.PARCEHIS_DATA_QUITACAO) ? "-1" : "0";
            dta.PARCEHIS_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.PARCEHIS_COD_EMPRESA) ? "-1" : "0";
            dta.APOLICES_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}