using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class A1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1 : QueryBasis<A1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT RAMO_VG, RAMO_AP, RAMO_VGAPC,
            RAMO_SAUDE, RAMO_EDUCACAO
            INTO :PARM-RAMO-VG, :PARM-RAMO-AP,
            :PARM-RAMO-VGAPC,
            :PARM-RAMO-SAUDE,
            :PARM-RAMO-PRESTA
            FROM SEGUROS.V1PARAMRAMO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_VG
							, RAMO_AP
							, RAMO_VGAPC
							,
											RAMO_SAUDE
							, RAMO_EDUCACAO
											FROM SEGUROS.V1PARAMRAMO
											WITH UR";

            return query;
        }
        public string PARM_RAMO_VG { get; set; }
        public string PARM_RAMO_AP { get; set; }
        public string PARM_RAMO_VGAPC { get; set; }
        public string PARM_RAMO_SAUDE { get; set; }
        public string PARM_RAMO_PRESTA { get; set; }

        public static A1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1 Execute(A1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1 a1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1)
        {
            var ths = a1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override A1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new A1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARM_RAMO_VG = result[i++].Value?.ToString();
            dta.PARM_RAMO_AP = result[i++].Value?.ToString();
            dta.PARM_RAMO_VGAPC = result[i++].Value?.ToString();
            dta.PARM_RAMO_SAUDE = result[i++].Value?.ToString();
            dta.PARM_RAMO_PRESTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}