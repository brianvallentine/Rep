using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1_Query1 : QueryBasis<R8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCT_IOCC_RAMO,
            IND_ISENCAO_CUSTO
            INTO :RAMOCOMP-PCT-IOCC-RAMO,
            :RAMOCOMP-IND-ISENCAO-CUSTO
            FROM SEGUROS.RAMO_COMPLEMENTAR
            WHERE RAMO_EMISSOR = :RAMOCOMP-RAMO-EMISSOR
            AND DATA_INIVIGENCIA < :WS-DTA-INI-VIGENCIA
            AND DATA_TERVIGENCIA > :WS-DTA-INI-VIGENCIA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCT_IOCC_RAMO
							,
											IND_ISENCAO_CUSTO
											FROM SEGUROS.RAMO_COMPLEMENTAR
											WHERE RAMO_EMISSOR = '{this.RAMOCOMP_RAMO_EMISSOR}'
											AND DATA_INIVIGENCIA < '{this.WS_DTA_INI_VIGENCIA}'
											AND DATA_TERVIGENCIA > '{this.WS_DTA_INI_VIGENCIA}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string RAMOCOMP_PCT_IOCC_RAMO { get; set; }
        public string RAMOCOMP_IND_ISENCAO_CUSTO { get; set; }
        public string RAMOCOMP_RAMO_EMISSOR { get; set; }
        public string WS_DTA_INI_VIGENCIA { get; set; }

        public static R8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1_Query1 Execute(R8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1_Query1 r8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1_Query1)
        {
            var ths = r8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1_Query1();
            var i = 0;
            dta.RAMOCOMP_PCT_IOCC_RAMO = result[i++].Value?.ToString();
            dta.RAMOCOMP_IND_ISENCAO_CUSTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}