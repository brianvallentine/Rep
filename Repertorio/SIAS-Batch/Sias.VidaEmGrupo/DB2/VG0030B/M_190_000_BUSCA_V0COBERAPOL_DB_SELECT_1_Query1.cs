using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0030B
{
    public class M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1 : QueryBasis<M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA
            INTO :DATA-INIVIGENCIA-C
            FROM SEGUROS.V0COBERAPOL
            WHERE NUM_APOLICE = :MNUM-APOLICE
            AND NRENDOS = 0
            AND NUM_ITEM = :SNUM-ITEM
            AND OCORHIST = :SOCORR-HISTORICO
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
											FROM SEGUROS.V0COBERAPOL
											WHERE NUM_APOLICE = '{this.MNUM_APOLICE}'
											AND NRENDOS = 0
											AND NUM_ITEM = '{this.SNUM_ITEM}'
											AND OCORHIST = '{this.SOCORR_HISTORICO}'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string DATA_INIVIGENCIA_C { get; set; }
        public string SOCORR_HISTORICO { get; set; }
        public string MNUM_APOLICE { get; set; }
        public string SNUM_ITEM { get; set; }

        public static M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1 Execute(M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1 m_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1)
        {
            var ths = m_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.DATA_INIVIGENCIA_C = result[i++].Value?.ToString();
            return dta;
        }

    }
}