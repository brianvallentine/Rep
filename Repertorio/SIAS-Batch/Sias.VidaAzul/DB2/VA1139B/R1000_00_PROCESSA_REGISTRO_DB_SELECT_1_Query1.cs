using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1139B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO,
            CODPRODU
            ,ORGAO
            INTO :V0APOL-RAMO,
            :V0APOL-CODPRODU
            ,:V0APOL-ORGAO
            FROM SEGUROS.V0APOLICE
            WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO
							,
											CODPRODU
											,ORGAO
											FROM SEGUROS.V0APOLICE
											WHERE NUM_APOLICE = '{this.V0HCTB_NUM_APOLICE}'";

            return query;
        }
        public string V0APOL_RAMO { get; set; }
        public string V0APOL_CODPRODU { get; set; }
        public string V0APOL_ORGAO { get; set; }
        public string V0HCTB_NUM_APOLICE { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0APOL_RAMO = result[i++].Value?.ToString();
            dta.V0APOL_CODPRODU = result[i++].Value?.ToString();
            dta.V0APOL_ORGAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}