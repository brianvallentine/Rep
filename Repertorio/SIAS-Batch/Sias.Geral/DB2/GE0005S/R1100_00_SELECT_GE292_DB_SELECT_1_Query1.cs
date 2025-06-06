using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0005S
{
    public class R1100_00_SELECT_GE292_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_GE292_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_GRUPO_SUSEP ,
            A.COD_RAMO_SUSEP
            INTO :GE292-COD-GRUPO-SUSEP ,
            :GE292-COD-RAMO-SUSEP
            FROM SEGUROS.GE_GRUPO_SUSEP A
            WHERE A.RAMO_EMISSOR = :GE292-RAMO-EMISSOR
            AND A.COD_MODALIDADE = :GE292-COD-MODALIDADE
            AND A.DTH_INI_VIGENCIA <= :GE292-DTH-INI-VIGENCIA
            AND A.DTH_FIM_VIGENCIA >= :GE292-DTH-INI-VIGENCIA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_GRUPO_SUSEP 
							,
											A.COD_RAMO_SUSEP
											FROM SEGUROS.GE_GRUPO_SUSEP A
											WHERE A.RAMO_EMISSOR = '{this.GE292_RAMO_EMISSOR}'
											AND A.COD_MODALIDADE = '{this.GE292_COD_MODALIDADE}'
											AND A.DTH_INI_VIGENCIA <= '{this.GE292_DTH_INI_VIGENCIA}'
											AND A.DTH_FIM_VIGENCIA >= '{this.GE292_DTH_INI_VIGENCIA}'";

            return query;
        }
        public string GE292_COD_GRUPO_SUSEP { get; set; }
        public string GE292_COD_RAMO_SUSEP { get; set; }
        public string GE292_DTH_INI_VIGENCIA { get; set; }
        public string GE292_COD_MODALIDADE { get; set; }
        public string GE292_RAMO_EMISSOR { get; set; }

        public static R1100_00_SELECT_GE292_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_GE292_DB_SELECT_1_Query1 r1100_00_SELECT_GE292_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_GE292_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_GE292_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_GE292_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE292_COD_GRUPO_SUSEP = result[i++].Value?.ToString();
            dta.GE292_COD_RAMO_SUSEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}