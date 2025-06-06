using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1 : QueryBasis<R1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-COUNT-COBER
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND OCORR_HISTORICO = '{this.SEGURVGA_OCORR_HISTORICO}'";

            return query;
        }
        public string WHOST_COUNT_COBER { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }

        public static R1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1 Execute(R1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1 r1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1)
        {
            var ths = r1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COUNT_COBER = result[i++].Value?.ToString();
            return dta;
        }

    }
}