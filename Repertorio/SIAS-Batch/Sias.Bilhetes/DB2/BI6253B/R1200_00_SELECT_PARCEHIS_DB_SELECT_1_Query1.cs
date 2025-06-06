using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6253B
{
    public class R1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            ,NUM_ENDOSSO
            ,NUM_PARCELA
            ,DAC_PARCELA
            ,OCORR_HISTORICO
            ,PRM_TARIFARIO
            ,VAL_DESCONTO
            ,PRM_LIQUIDO
            ,ADICIONAL_FRACIO
            ,VAL_CUSTO_EMISSAO
            ,VAL_IOCC
            ,PRM_TOTAL
            ,DATA_VENCIMENTO
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
            ,:PARCEHIS-DATA-VENCIMENTO
            FROM SEGUROS.PARCELA_HISTORICO
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO
            AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA
            AND OCORR_HISTORICO = :PARCEHIS-OCORR-HISTORICO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											,NUM_ENDOSSO
											,NUM_PARCELA
											,DAC_PARCELA
											,OCORR_HISTORICO
											,PRM_TARIFARIO
											,VAL_DESCONTO
											,PRM_LIQUIDO
											,ADICIONAL_FRACIO
											,VAL_CUSTO_EMISSAO
											,VAL_IOCC
											,PRM_TOTAL
											,DATA_VENCIMENTO
											FROM SEGUROS.PARCELA_HISTORICO
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCEHIS_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.PARCEHIS_NUM_PARCELA}'
											AND OCORR_HISTORICO = '{this.PARCEHIS_OCORR_HISTORICO}'
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
        public string PARCEHIS_DATA_VENCIMENTO { get; set; }

        public static R1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 r1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1();
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
            dta.PARCEHIS_DATA_VENCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}