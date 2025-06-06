using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_USUARIO
            INTO :RELATORI-COD-USUARIO
            FROM SEGUROS.RELATORIOS
            WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF
            AND COD_RELATORIO = 'VA0469B'
            AND SIT_REGISTRO = '0'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_USUARIO
											FROM SEGUROS.RELATORIOS
											WHERE NUM_CERTIFICADO = '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											AND COD_RELATORIO = 'VA0469B'
											AND SIT_REGISTRO = '0'";

            return query;
        }
        public string RELATORI_COD_USUARIO { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1 Execute(R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1 r3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = r3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_COD_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}