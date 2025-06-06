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
    public class DB010_ACESSA_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<DB010_ACESSA_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE
            INTO :ENDOSSOS-COD-FONTE
            FROM SEGUROS.ENDOSSOS
            WHERE COD_FONTE = :ENDOSSOS-COD-FONTE
            AND NUM_PROPOSTA = :ENDOSSOS-NUM-PROPOSTA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
											FROM SEGUROS.ENDOSSOS
											WHERE COD_FONTE = '{this.ENDOSSOS_COD_FONTE}'
											AND NUM_PROPOSTA = '{this.ENDOSSOS_NUM_PROPOSTA}'";

            return query;
        }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string ENDOSSOS_NUM_PROPOSTA { get; set; }

        public static DB010_ACESSA_ENDOSSOS_DB_SELECT_1_Query1 Execute(DB010_ACESSA_ENDOSSOS_DB_SELECT_1_Query1 dB010_ACESSA_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = dB010_ACESSA_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB010_ACESSA_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB010_ACESSA_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}