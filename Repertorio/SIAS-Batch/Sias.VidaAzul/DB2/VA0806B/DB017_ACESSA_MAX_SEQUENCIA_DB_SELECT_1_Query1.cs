using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0806B
{
    public class DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1 : QueryBasis<DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(SEQ_GERACAO)
            INTO :GEARDETA-SEQ-GERACAO
            FROM SEGUROS.GE_AR_DETALHE
            WHERE NOM_ARQUIVO = :GEARDETA-NOM-ARQUIVO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(SEQ_GERACAO)
											FROM SEGUROS.GE_AR_DETALHE
											WHERE NOM_ARQUIVO = '{this.GEARDETA_NOM_ARQUIVO}'";

            return query;
        }
        public string GEARDETA_SEQ_GERACAO { get; set; }
        public string GEARDETA_NOM_ARQUIVO { get; set; }

        public static DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1 Execute(DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1 dB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1)
        {
            var ths = dB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEARDETA_SEQ_GERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}