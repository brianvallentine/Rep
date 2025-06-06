using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0040B
{
    public class M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1_Query1 : QueryBasis<M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            INTO :V0RELA-NUM-APOLICE
            FROM
            SEGUROS.V0RELATORIOS
            WHERE
            CODRELAT IN ( 'VP0198B' , 'VP0199B' )
            AND NRCERTIF = :MNUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											FROM
											SEGUROS.V0RELATORIOS
											WHERE
											CODRELAT IN ( 'VP0198B' 
							, 'VP0199B' )
											AND NRCERTIF = '{this.MNUM_CERTIFICADO}'";

            return query;
        }
        public string V0RELA_NUM_APOLICE { get; set; }
        public string MNUM_CERTIFICADO { get; set; }

        public static M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1_Query1 Execute(M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1_Query1 m_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1_Query1)
        {
            var ths = m_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RELA_NUM_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}