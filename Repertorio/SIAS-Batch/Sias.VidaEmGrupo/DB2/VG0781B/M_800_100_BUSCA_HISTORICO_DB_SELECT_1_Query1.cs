using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0781B
{
    public class M_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1 : QueryBasis<M_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(VLPRMLIQ), 0),
            VALUE(MAX(DTQITBCO), DATE( ' ' )),
            VALUE(MAX(DTMOVTO), DATE( ' ' ))
            INTO
            :V0ENDOPARC-VLPRMLIQ,
            :V0ENDOPARC-DTQITBCO,
            :V0ENDOPARC-DTMOVTO
            FROM
            SEGUROS.V0HISTOPARC
            WHERE
            NUM_APOLICE = :V1RELATORIOS-APOLICE AND
            NRENDOS = :V0ENDOPARC-NRENDOS AND
            OPERACAO >= 200 AND
            OPERACAO <= 299
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(VLPRMLIQ)
							, 0)
							,
											VALUE(MAX(DTQITBCO)
							, DATE( ' ' ))
							,
											VALUE(MAX(DTMOVTO)
							, DATE( ' ' ))
											FROM
											SEGUROS.V0HISTOPARC
											WHERE
											NUM_APOLICE = '{this.V1RELATORIOS_APOLICE}' AND
											NRENDOS = '{this.V0ENDOPARC_NRENDOS}' AND
											OPERACAO >= 200 AND
											OPERACAO <= 299";

            return query;
        }
        public string V0ENDOPARC_VLPRMLIQ { get; set; }
        public string V0ENDOPARC_DTQITBCO { get; set; }
        public string V0ENDOPARC_DTMOVTO { get; set; }
        public string V1RELATORIOS_APOLICE { get; set; }
        public string V0ENDOPARC_NRENDOS { get; set; }

        public static M_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1 Execute(M_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1 m_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1)
        {
            var ths = m_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDOPARC_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V0ENDOPARC_DTQITBCO = result[i++].Value?.ToString();
            dta.V0ENDOPARC_DTMOVTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}