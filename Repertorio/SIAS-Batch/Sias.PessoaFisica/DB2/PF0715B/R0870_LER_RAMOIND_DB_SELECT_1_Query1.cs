using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0715B
{
    public class R0870_LER_RAMOIND_DB_SELECT_1_Query1 : QueryBasis<R0870_LER_RAMOIND_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            PCT_IOCC_RAMO
            INTO
            :RAMOCOMP-PCT-IOCC-RAMO
            FROM SEGUROS.RAMO_COMPLEMENTAR
            WHERE RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR
            AND DATA_INIVIGENCIA <= :VGTERNIV-DTH-INI-VIGENCIA
            AND DATA_TERVIGENCIA >= :VGTERNIV-DTH-INI-VIGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											PCT_IOCC_RAMO
											FROM SEGUROS.RAMO_COMPLEMENTAR
											WHERE RAMO_EMISSOR = '{this.APOLICES_RAMO_EMISSOR}'
											AND DATA_INIVIGENCIA <= '{this.VGTERNIV_DTH_INI_VIGENCIA}'
											AND DATA_TERVIGENCIA >= '{this.VGTERNIV_DTH_INI_VIGENCIA}'
											WITH UR";

            return query;
        }
        public string RAMOCOMP_PCT_IOCC_RAMO { get; set; }
        public string VGTERNIV_DTH_INI_VIGENCIA { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }

        public static R0870_LER_RAMOIND_DB_SELECT_1_Query1 Execute(R0870_LER_RAMOIND_DB_SELECT_1_Query1 r0870_LER_RAMOIND_DB_SELECT_1_Query1)
        {
            var ths = r0870_LER_RAMOIND_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0870_LER_RAMOIND_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0870_LER_RAMOIND_DB_SELECT_1_Query1();
            var i = 0;
            dta.RAMOCOMP_PCT_IOCC_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}