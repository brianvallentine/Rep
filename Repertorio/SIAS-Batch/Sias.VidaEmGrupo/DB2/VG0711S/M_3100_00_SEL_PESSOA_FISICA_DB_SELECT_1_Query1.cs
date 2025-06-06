using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0711S
{
    public class M_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1 : QueryBasis<M_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PESSOFIS.COD_CBO
            INTO :PESSOFIS-COD-CBO
            FROM SEGUROS.PROPOSTA_FIDELIZ FIDELIZ
            , SEGUROS.PESSOA_FISICA PESSOFIS
            WHERE FIDELIZ.NUM_PROPOSTA_SIVPF = :WS-NUM-CERTIFICADO
            AND PESSOFIS.COD_PESSOA = FIDELIZ.COD_PESSOA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PESSOFIS.COD_CBO
											FROM SEGUROS.PROPOSTA_FIDELIZ FIDELIZ
											, SEGUROS.PESSOA_FISICA PESSOFIS
											WHERE FIDELIZ.NUM_PROPOSTA_SIVPF = '{this.WS_NUM_CERTIFICADO}'
											AND PESSOFIS.COD_PESSOA = FIDELIZ.COD_PESSOA
											WITH UR";

            return query;
        }
        public string PESSOFIS_COD_CBO { get; set; }
        public string WS_NUM_CERTIFICADO { get; set; }

        public static M_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1 Execute(M_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1 m_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1)
        {
            var ths = m_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOFIS_COD_CBO = result[i++].Value?.ToString();
            return dta;
        }

    }
}