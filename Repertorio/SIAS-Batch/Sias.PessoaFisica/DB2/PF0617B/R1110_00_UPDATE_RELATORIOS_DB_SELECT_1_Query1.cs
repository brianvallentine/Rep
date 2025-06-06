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
    public class R1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<R1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DIA_SEMANA
            INTO :WS-DIA-SEMANA
            FROM SEGUROS.CALENDARIO
            WHERE
            DATA_CALENDARIO = :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DIA_SEMANA
											FROM SEGUROS.CALENDARIO
											WHERE
											DATA_CALENDARIO = '{this.SISTEMAS_DATA_MOV_ABERTO}'
											WITH UR";

            return query;
        }
        public string WS_DIA_SEMANA { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1 Execute(R1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1 r1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = r1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DIA_SEMANA = result[i++].Value?.ToString();
            return dta;
        }

    }
}