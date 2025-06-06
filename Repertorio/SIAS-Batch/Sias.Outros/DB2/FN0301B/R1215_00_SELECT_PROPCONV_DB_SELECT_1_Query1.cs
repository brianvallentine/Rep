using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1 : QueryBasis<R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_VC
            INTO :WHOST-PROPOSTA-VC
            FROM SEGUROS.AU_PROP_CONV_VC A
            WHERE A.NUM_APOLICE = :V1ENDO-NUMAPOL
            AND A.DTH_INI_VIGENCIA =
            ( SELECT MAX (B.DTH_INI_VIGENCIA)
            FROM SEGUROS.AU_PROP_CONV_VC B
            WHERE B.NUM_APOLICE = A.NUM_APOLICE
            )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_VC
											FROM SEGUROS.AU_PROP_CONV_VC A
											WHERE A.NUM_APOLICE = '{this.V1ENDO_NUMAPOL}'
											AND A.DTH_INI_VIGENCIA =
											( SELECT MAX (B.DTH_INI_VIGENCIA)
											FROM SEGUROS.AU_PROP_CONV_VC B
											WHERE B.NUM_APOLICE = A.NUM_APOLICE
											)
											WITH UR";

            return query;
        }
        public string WHOST_PROPOSTA_VC { get; set; }
        public string V1ENDO_NUMAPOL { get; set; }

        public static R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1 Execute(R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1 r1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1)
        {
            var ths = r1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_PROPOSTA_VC = result[i++].Value?.ToString();
            return dta;
        }

    }
}