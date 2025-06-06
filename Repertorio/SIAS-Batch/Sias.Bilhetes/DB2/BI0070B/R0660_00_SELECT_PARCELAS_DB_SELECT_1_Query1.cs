using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0070B
{
    public class R0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1 : QueryBasis<R0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            ,NUM_PARCELA
            ,DAC_PARCELA
            ,COD_FONTE
            ,PRM_TARIFARIO_IX
            ,VAL_DESCONTO_IX
            ,PRM_LIQUIDO_IX
            ,ADICIONAL_FRAC_IX
            ,VAL_CUSTO_EMIS_IX
            ,VAL_IOCC_IX
            ,PRM_TOTAL_IX
            INTO :PARCELAS-NUM-APOLICE
            ,:PARCELAS-NUM-PARCELA
            ,:PARCELAS-DAC-PARCELA
            ,:PARCELAS-COD-FONTE
            ,:PARCELAS-PRM-TARIFARIO-IX
            ,:PARCELAS-VAL-DESCONTO-IX
            ,:PARCELAS-PRM-LIQUIDO-IX
            ,:PARCELAS-ADICIONAL-FRAC-IX
            ,:PARCELAS-VAL-CUSTO-EMIS-IX
            ,:PARCELAS-VAL-IOCC-IX
            ,:PARCELAS-PRM-TOTAL-IX
            FROM SEGUROS.PARCELAS
            WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND NUM_ENDOSSO = :WHOST-NUM-ENDOSSO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											,NUM_PARCELA
											,DAC_PARCELA
											,COD_FONTE
											,PRM_TARIFARIO_IX
											,VAL_DESCONTO_IX
											,PRM_LIQUIDO_IX
											,ADICIONAL_FRAC_IX
											,VAL_CUSTO_EMIS_IX
											,VAL_IOCC_IX
											,PRM_TOTAL_IX
											FROM SEGUROS.PARCELAS
											WHERE NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.WHOST_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }
        public string PARCELAS_DAC_PARCELA { get; set; }
        public string PARCELAS_COD_FONTE { get; set; }
        public string PARCELAS_PRM_TARIFARIO_IX { get; set; }
        public string PARCELAS_VAL_DESCONTO_IX { get; set; }
        public string PARCELAS_PRM_LIQUIDO_IX { get; set; }
        public string PARCELAS_ADICIONAL_FRAC_IX { get; set; }
        public string PARCELAS_VAL_CUSTO_EMIS_IX { get; set; }
        public string PARCELAS_VAL_IOCC_IX { get; set; }
        public string PARCELAS_PRM_TOTAL_IX { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string WHOST_NUM_ENDOSSO { get; set; }

        public static R0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1 Execute(R0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1 r0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1)
        {
            var ths = r0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCELAS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PARCELAS_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PARCELAS_DAC_PARCELA = result[i++].Value?.ToString();
            dta.PARCELAS_COD_FONTE = result[i++].Value?.ToString();
            dta.PARCELAS_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.PARCELAS_VAL_DESCONTO_IX = result[i++].Value?.ToString();
            dta.PARCELAS_PRM_LIQUIDO_IX = result[i++].Value?.ToString();
            dta.PARCELAS_ADICIONAL_FRAC_IX = result[i++].Value?.ToString();
            dta.PARCELAS_VAL_CUSTO_EMIS_IX = result[i++].Value?.ToString();
            dta.PARCELAS_VAL_IOCC_IX = result[i++].Value?.ToString();
            dta.PARCELAS_PRM_TOTAL_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}