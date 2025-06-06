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
    public class DB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1 : QueryBasis<DB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTH_ANO_REFERENCIA
            , DTH_MES_REFERENCIA
            INTO :GEARDETA-DTH-ANO-REFERENCIA
            , :GEARDETA-DTH-MES-REFERENCIA
            FROM SEGUROS.GE_AR_DETALHE
            WHERE NOM_ARQUIVO = :GEARDETA-NOM-ARQUIVO
            AND SEQ_GERACAO = :GEARDETA-SEQ-GERACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTH_ANO_REFERENCIA
											, DTH_MES_REFERENCIA
											FROM SEGUROS.GE_AR_DETALHE
											WHERE NOM_ARQUIVO = '{this.GEARDETA_NOM_ARQUIVO}'
											AND SEQ_GERACAO = '{this.GEARDETA_SEQ_GERACAO}'";

            return query;
        }
        public string GEARDETA_DTH_ANO_REFERENCIA { get; set; }
        public string GEARDETA_DTH_MES_REFERENCIA { get; set; }
        public string GEARDETA_NOM_ARQUIVO { get; set; }
        public string GEARDETA_SEQ_GERACAO { get; set; }

        public static DB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1 Execute(DB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1 dB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1)
        {
            var ths = dB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEARDETA_DTH_ANO_REFERENCIA = result[i++].Value?.ToString();
            dta.GEARDETA_DTH_MES_REFERENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}