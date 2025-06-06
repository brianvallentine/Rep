using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1 : QueryBasis<M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCIOF
            INTO :V1RIND-PCIOF
            FROM SEGUROS.V1RAMOIND
            WHERE RAMO = :V1APOL-RAMO
            AND DTINIVIG <= :V1RIND-DTINIVIG
            AND DTTERVIG >= :V1RIND-DTINIVIG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCIOF
											FROM SEGUROS.V1RAMOIND
											WHERE RAMO = '{this.V1APOL_RAMO}'
											AND DTINIVIG <= '{this.V1RIND_DTINIVIG}'
											AND DTTERVIG >= '{this.V1RIND_DTINIVIG}'
											WITH UR";

            return query;
        }
        public string V1RIND_PCIOF { get; set; }
        public string V1RIND_DTINIVIG { get; set; }
        public string V1APOL_RAMO { get; set; }

        public static M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1 Execute(M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1 m_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1)
        {
            var ths = m_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1();
            var i = 0;
            dta.V1RIND_PCIOF = result[i++].Value?.ToString();
            return dta;
        }

    }
}