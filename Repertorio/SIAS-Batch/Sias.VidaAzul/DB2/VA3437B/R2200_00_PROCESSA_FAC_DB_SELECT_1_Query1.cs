using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3437B
{
    public class R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1 : QueryBasis<R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOVIMENTO,
            COD_OPERACAO,
            COD_MOEDA_PRM
            INTO :SEGVGAPH-DATA-MOVIMENTO,
            :SEGVGAPH-COD-OPERACAO,
            :SEGVGAPH-COD-MOEDA-PRM:VIND-CODMOEDA-I
            FROM SEGUROS.SEGURADOSVGAP_HIST
            WHERE NUM_APOLICE = :WHOST-NRAPOLICE
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOVIMENTO
							,
											COD_OPERACAO
							,
											COD_MOEDA_PRM
											FROM SEGUROS.SEGURADOSVGAP_HIST
											WHERE NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND OCORR_HISTORICO = '{this.SEGURVGA_OCORR_HISTORICO}'
											WITH UR";

            return query;
        }
        public string SEGVGAPH_DATA_MOVIMENTO { get; set; }
        public string SEGVGAPH_COD_OPERACAO { get; set; }
        public string SEGVGAPH_COD_MOEDA_PRM { get; set; }
        public string VIND_CODMOEDA_I { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string WHOST_NRAPOLICE { get; set; }

        public static R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1 Execute(R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1 r2200_00_PROCESSA_FAC_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_PROCESSA_FAC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGVGAPH_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SEGVGAPH_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SEGVGAPH_COD_MOEDA_PRM = result[i++].Value?.ToString();
            dta.VIND_CODMOEDA_I = string.IsNullOrWhiteSpace(dta.SEGVGAPH_COD_MOEDA_PRM) ? "-1" : "0";
            return dta;
        }

    }
}