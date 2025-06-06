using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0050B
{
    public class R0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1 : QueryBasis<R0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA ,
            MES_REFERENCIA ,
            ANO_REFERENCIA ,
            SITUACAO
            INTO :V1RELA-DATA-REFER ,
            :V1RELA-MES-REFER ,
            :V1RELA-ANO-REFER ,
            :V1RELA-SITUACAO
            FROM SEGUROS.V1RELATORIOS
            WHERE CODRELAT = 'VP0050B1'
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA 
							,
											MES_REFERENCIA 
							,
											ANO_REFERENCIA 
							,
											SITUACAO
											FROM SEGUROS.V1RELATORIOS
											WHERE CODRELAT = 'VP0050B1'
											AND SITUACAO = '0'";

            return query;
        }
        public string V1RELA_DATA_REFER { get; set; }
        public string V1RELA_MES_REFER { get; set; }
        public string V1RELA_ANO_REFER { get; set; }
        public string V1RELA_SITUACAO { get; set; }

        public static R0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1 Execute(R0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1 r0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_SELECT_V1RELATORIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1RELA_DATA_REFER = result[i++].Value?.ToString();
            dta.V1RELA_MES_REFER = result[i++].Value?.ToString();
            dta.V1RELA_ANO_REFER = result[i++].Value?.ToString();
            dta.V1RELA_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}