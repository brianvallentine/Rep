using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 : QueryBasis<R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA,
            DATA_REFERENCIA
            INTO :DCLRELATORIOS.RELATORI-DATA-REFERENCIA,
            :WHOST-DATA-REF-CURSOR
            FROM SEGUROS.RELATORIOS
            WHERE IDE_SISTEMA = 'PF'
            AND COD_RELATORIO = 'PF0617B'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA
							,
											DATA_REFERENCIA
											FROM SEGUROS.RELATORIOS
											WHERE IDE_SISTEMA = 'PF'
											AND COD_RELATORIO = 'PF0617B'
											WITH UR";

            return query;
        }
        public string RELATORI_DATA_REFERENCIA { get; set; }
        public string WHOST_DATA_REF_CURSOR { get; set; }

        public static R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 Execute(R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 r0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1)
        {
            var ths = r0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_DATA_REFERENCIA = result[i++].Value?.ToString();
            dta.WHOST_DATA_REF_CURSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}