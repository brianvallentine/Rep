using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1 : QueryBasis<R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRCERTIF
            ,NRPARCEL
            ,NRTIT
            ,VLPRMTOT
            ,SITUACAO
            ,OCORHIST
            ,CODOPER
            ,OPCAOPAG
            ,DTVENCTO
            INTO :V0HCOB-NRCERTIF
            ,:V0HCOB-NRPARCEL
            ,:V0HCOB-NRTIT
            ,:V0HCOB-VLPRMTOT
            ,:V0HCOB-SITUACAO
            ,:V0HCOB-OCORHIST
            ,:V0HCOB-CODOPER
            ,:V0HCOB-OPCAOPAG
            ,:V0HCOB-DTVENCTO
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRTIT = :V0MOVC-NRTIT
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRCERTIF
											,NRPARCEL
											,NRTIT
											,VLPRMTOT
											,SITUACAO
											,OCORHIST
											,CODOPER
											,OPCAOPAG
											,DTVENCTO
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRTIT = '{this.V0MOVC_NRTIT}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCOB_VLPRMTOT { get; set; }
        public string V0HCOB_SITUACAO { get; set; }
        public string V0HCOB_OCORHIST { get; set; }
        public string V0HCOB_CODOPER { get; set; }
        public string V0HCOB_OPCAOPAG { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }
        public string V0MOVC_NRTIT { get; set; }

        public static R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1 Execute(R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1 r0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HCOB_NRCERTIF = result[i++].Value?.ToString();
            dta.V0HCOB_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HCOB_NRTIT = result[i++].Value?.ToString();
            dta.V0HCOB_VLPRMTOT = result[i++].Value?.ToString();
            dta.V0HCOB_SITUACAO = result[i++].Value?.ToString();
            dta.V0HCOB_OCORHIST = result[i++].Value?.ToString();
            dta.V0HCOB_CODOPER = result[i++].Value?.ToString();
            dta.V0HCOB_OPCAOPAG = result[i++].Value?.ToString();
            dta.V0HCOB_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}