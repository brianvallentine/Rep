using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :V0PROE-CODPRODU
            FROM SEGUROS.V0PROP_ESTIPULANTE
            WHERE NUMBIL = :V0BILH-NUMBIL
            AND FONTE = 0
            AND NUM_PROPOSTA = 0
            AND COD_FROTA = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.V0PROP_ESTIPULANTE
											WHERE NUMBIL = '{this.V0BILH_NUMBIL}'
											AND FONTE = 0
											AND NUM_PROPOSTA = 0
											AND COD_FROTA = '0'";

            return query;
        }
        public string V0PROE_CODPRODU { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1();
            var i = 0;
            dta.V0PROE_CODPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}