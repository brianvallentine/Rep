using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<R2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_USUARIO
            INTO :RELATORI-COD-USUARIO
            FROM SEGUROS.RELATORIOS
            WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND DATA_SOLICITACAO = :V1SIST-DTMOVABE
            AND COD_RELATORIO = 'VA0469B'
            AND NUM_PARCELA = 01
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_USUARIO
											FROM SEGUROS.RELATORIOS
											WHERE NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND DATA_SOLICITACAO = '{this.V1SIST_DTMOVABE}'
											AND COD_RELATORIO = 'VA0469B'
											AND NUM_PARCELA = 01";

            return query;
        }
        public string RELATORI_COD_USUARIO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static R2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1 Execute(R2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1 r2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = r2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_COD_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}