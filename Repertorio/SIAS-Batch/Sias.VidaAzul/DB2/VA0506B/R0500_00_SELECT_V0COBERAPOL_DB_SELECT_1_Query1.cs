using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0506B
{
    public class R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 : QueryBasis<R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(PCT_COBERTURA)
            INTO :WHOST-PCTCOBER:VIND-PCTCOB
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE
            AND NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO
            AND NUM_ITEM = 0
            AND COD_COBERTURA = 0
            AND PCT_COBERTURA > 0
            AND DATA_INIVIGENCIA <= :ENDOSSOS-DATA-INIVIGENCIA
            AND DATA_TERVIGENCIA >= :ENDOSSOS-DATA-INIVIGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(PCT_COBERTURA)
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.HISCONPA_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.HISCONPA_NUM_ENDOSSO}'
											AND NUM_ITEM = 0
											AND COD_COBERTURA = 0
											AND PCT_COBERTURA > 0
											AND DATA_INIVIGENCIA <= '{this.ENDOSSOS_DATA_INIVIGENCIA}'
											AND DATA_TERVIGENCIA >= '{this.ENDOSSOS_DATA_INIVIGENCIA}'
											WITH UR";

            return query;
        }
        public string WHOST_PCTCOBER { get; set; }
        public string VIND_PCTCOB { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }

        public static R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 Execute(R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 r0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1)
        {
            var ths = r0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_PCTCOBER = result[i++].Value?.ToString();
            dta.VIND_PCTCOB = string.IsNullOrWhiteSpace(dta.WHOST_PCTCOBER) ? "-1" : "0";
            return dta;
        }

    }
}