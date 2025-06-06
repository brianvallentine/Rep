using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0142B
{
    public class R0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1 : QueryBasis<R0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-COUNT2:VIND-COUNT
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            AND NUM_ITEM = 0
            AND COD_COBERTURA <> 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'
											AND NUM_ITEM = 0
											AND COD_COBERTURA <> 0
											WITH UR";

            return query;
        }
        public string WHOST_COUNT2 { get; set; }
        public string VIND_COUNT { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static R0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1 Execute(R0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1 r0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1)
        {
            var ths = r0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COUNT2 = result[i++].Value?.ToString();
            dta.VIND_COUNT = string.IsNullOrWhiteSpace(dta.WHOST_COUNT2) ? "-1" : "0";
            return dta;
        }

    }
}