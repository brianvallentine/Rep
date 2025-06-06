using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8008B
{
    public class M_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1 : QueryBasis<M_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SEQ_GERACAO
            INTO :GEARDETA-SEQ-GERACAO
            FROM SEGUROS.GE_AR_DETALHE
            WHERE NOM_ARQUIVO = 'R608800'
            AND SEQ_GERACAO = :GEARDETA-SEQ-GERACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SEQ_GERACAO
											FROM SEGUROS.GE_AR_DETALHE
											WHERE NOM_ARQUIVO = 'R608800'
											AND SEQ_GERACAO = '{this.GEARDETA_SEQ_GERACAO}'";

            return query;
        }
        public string GEARDETA_SEQ_GERACAO { get; set; }

        public static M_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1 Execute(M_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1 m_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1)
        {
            var ths = m_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEARDETA_SEQ_GERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}