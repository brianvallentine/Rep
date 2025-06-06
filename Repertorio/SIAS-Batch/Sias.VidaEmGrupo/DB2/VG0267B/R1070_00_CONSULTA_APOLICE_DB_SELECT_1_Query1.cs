using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0267B
{
    public class R1070_00_CONSULTA_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R1070_00_CONSULTA_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(B.PCT_IOCC_RAMO, 0)
            INTO :RAMOCOMP-PCT-IOCC-RAMO
            FROM SEGUROS.V0APOLICE A,
            SEGUROS.RAMO_COMPLEMENTAR B
            WHERE A.NUM_APOLICE = :V0HIST-NRAPOLICE
            AND A.RAMO = B.RAMO_EMISSOR
            AND B.DATA_INIVIGENCIA <= :V1SIST-DTMOVABE
            AND B.DATA_TERVIGENCIA >= :V1SIST-DTMOVABE
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(B.PCT_IOCC_RAMO
							, 0)
											FROM SEGUROS.V0APOLICE A
							,
											SEGUROS.RAMO_COMPLEMENTAR B
											WHERE A.NUM_APOLICE = '{this.V0HIST_NRAPOLICE}'
											AND A.RAMO = B.RAMO_EMISSOR
											AND B.DATA_INIVIGENCIA <= '{this.V1SIST_DTMOVABE}'
											AND B.DATA_TERVIGENCIA >= '{this.V1SIST_DTMOVABE}'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string RAMOCOMP_PCT_IOCC_RAMO { get; set; }
        public string V0HIST_NRAPOLICE { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static R1070_00_CONSULTA_APOLICE_DB_SELECT_1_Query1 Execute(R1070_00_CONSULTA_APOLICE_DB_SELECT_1_Query1 r1070_00_CONSULTA_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r1070_00_CONSULTA_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1070_00_CONSULTA_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1070_00_CONSULTA_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.RAMOCOMP_PCT_IOCC_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}