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
    public class DB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1_Query1 : QueryBasis<DB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CNAE_ATIVIDADE
            INTO :GE374-COD-CNAE-ATIVIDADE
            FROM SEGUROS.GE_CNAE_ATIVIDADE
            WHERE COD_CNAE_ATIVIDADE = :GE374-COD-CNAE-ATIVIDADE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_CNAE_ATIVIDADE
											FROM SEGUROS.GE_CNAE_ATIVIDADE
											WHERE COD_CNAE_ATIVIDADE = '{this.GE374_COD_CNAE_ATIVIDADE}'
											WITH UR";

            return query;
        }
        public string GE374_COD_CNAE_ATIVIDADE { get; set; }

        public static DB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1_Query1 Execute(DB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1_Query1 dB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1_Query1)
        {
            var ths = dB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE374_COD_CNAE_ATIVIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}