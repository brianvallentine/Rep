using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI2002B
{
    public class R0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 : QueryBasis<R0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NUM_APOLICE
            ,B.NUM_ENDOSSO
            ,B.NUM_PARCELA
            ,B.DAC_PARCELA
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
            ,B.ENDOS_CANCELA
            ,B.SIT_CONTABIL
            ,B.RENUM_DOCUMENTO
            ,B.COD_EMPRESA
            INTO :PARCEHIS-NUM-APOLICE
            ,:PARCEHIS-NUM-ENDOSSO
            ,:PARCEHIS-NUM-PARCELA
            ,:PARCEHIS-DAC-PARCELA
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
            ,:PARCEHIS-ENDOS-CANCELA
            ,:PARCEHIS-SIT-CONTABIL
            ,:PARCEHIS-RENUM-DOCUMENTO
            ,:PARCEHIS-COD-EMPRESA:VIND-NULL02
            FROM SEGUROS.PARCELAS A
            ,SEGUROS.PARCELA_HISTORICO B
            WHERE A.NUM_APOLICE = :CBCONDEV-NUM-APOLICE
            AND A.NUM_ENDOSSO = :CBCONDEV-NUM-ENDOSSO
            AND A.NUM_PARCELA = :CBCONDEV-NUM-PARCELA
            AND A.SIT_REGISTRO = '0'
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
            AND A.NUM_PARCELA = B.NUM_PARCELA
            AND A.OCORR_HISTORICO = B.OCORR_HISTORICO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.NUM_APOLICE
											,B.NUM_ENDOSSO
											,B.NUM_PARCELA
											,B.DAC_PARCELA
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
											,B.ENDOS_CANCELA
											,B.SIT_CONTABIL
											,B.RENUM_DOCUMENTO
											,B.COD_EMPRESA
											FROM SEGUROS.PARCELAS A
											,SEGUROS.PARCELA_HISTORICO B
											WHERE A.NUM_APOLICE = '{this.CBCONDEV_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.CBCONDEV_NUM_ENDOSSO}'
											AND A.NUM_PARCELA = '{this.CBCONDEV_NUM_PARCELA}'
											AND A.SIT_REGISTRO = '0'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
											AND A.NUM_PARCELA = B.NUM_PARCELA
											AND A.OCORR_HISTORICO = B.OCORR_HISTORICO
											WITH UR";

            return query;
        }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }
        public string PARCEHIS_DAC_PARCELA { get; set; }
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
        public string PARCEHIS_ENDOS_CANCELA { get; set; }
        public string PARCEHIS_SIT_CONTABIL { get; set; }
        public string PARCEHIS_RENUM_DOCUMENTO { get; set; }
        public string PARCEHIS_COD_EMPRESA { get; set; }
        public string VIND_NULL02 { get; set; }
        public string CBCONDEV_NUM_APOLICE { get; set; }
        public string CBCONDEV_NUM_ENDOSSO { get; set; }
        public string CBCONDEV_NUM_PARCELA { get; set; }

        public static R0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 Execute(R0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 r0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1)
        {
            var ths = r0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PARCEHIS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.PARCEHIS_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PARCEHIS_DAC_PARCELA = result[i++].Value?.ToString();
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
            dta.PARCEHIS_ENDOS_CANCELA = result[i++].Value?.ToString();
            dta.PARCEHIS_SIT_CONTABIL = result[i++].Value?.ToString();
            dta.PARCEHIS_RENUM_DOCUMENTO = result[i++].Value?.ToString();
            dta.PARCEHIS_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.PARCEHIS_COD_EMPRESA) ? "-1" : "0";
            return dta;
        }

    }
}