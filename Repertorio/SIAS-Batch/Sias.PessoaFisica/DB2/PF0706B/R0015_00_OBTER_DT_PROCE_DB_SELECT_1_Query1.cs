using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0706B
{
    public class R0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 : QueryBasis<R0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA,
            DATA_REFERENCIA - 10 DAYS
            INTO :DCLRELATORIOS.RELATORI-DATA-REFERENCIA,
            :WHOST-DATA-REF-CURSOR
            FROM SEGUROS.RELATORIOS
            WHERE IDE_SISTEMA = 'PF'
            AND COD_RELATORIO = 'PF0706B'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA
							,
											DATA_REFERENCIA - 10 DAYS
											FROM SEGUROS.RELATORIOS
											WHERE IDE_SISTEMA = 'PF'
											AND COD_RELATORIO = 'PF0706B'
											WITH UR";

            return query;
        }
        public string RELATORI_DATA_REFERENCIA { get; set; }
        public string WHOST_DATA_REF_CURSOR { get; set; }

        public static R0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 Execute(R0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 r0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1)
        {
            var ths = r0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_DATA_REFERENCIA = result[i++].Value?.ToString();
            dta.WHOST_DATA_REF_CURSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}