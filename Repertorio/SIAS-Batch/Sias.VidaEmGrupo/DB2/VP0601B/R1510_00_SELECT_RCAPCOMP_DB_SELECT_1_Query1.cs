using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 : QueryBasis<R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT BCO_AVISO,
            AGE_AVISO,
            NUM_AVISO_CREDITO,
            DATA_MOVIMENTO,
            DATA_RCAP
            INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO,
            :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO,
            :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO,
            :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO,
            :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP
            FROM SEGUROS.RCAP_COMPLEMENTAR
            WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE
            AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP
            AND NUM_RCAP_COMPLEMEN = 0
            AND COD_OPERACAO BETWEEN 100 AND 199
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT BCO_AVISO
							,
											AGE_AVISO
							,
											NUM_AVISO_CREDITO
							,
											DATA_MOVIMENTO
							,
											DATA_RCAP
											FROM SEGUROS.RCAP_COMPLEMENTAR
											WHERE COD_FONTE = '{this.RCAPS_COD_FONTE}'
											AND NUM_RCAP = '{this.RCAPS_NUM_RCAP}'
											AND NUM_RCAP_COMPLEMEN = 0
											AND COD_OPERACAO BETWEEN 100 AND 199";

            return query;
        }
        public string RCAPCOMP_BCO_AVISO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string RCAPCOMP_DATA_MOVIMENTO { get; set; }
        public string RCAPCOMP_DATA_RCAP { get; set; }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }

        public static R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 Execute(R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 r1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1)
        {
            var ths = r1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPCOMP_BCO_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_AGE_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.RCAPCOMP_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.RCAPCOMP_DATA_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}