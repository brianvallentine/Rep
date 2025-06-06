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
    public class M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1 : QueryBasis<M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_ITEM
            INTO :SNUM-ITEM
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO
            AND TIPO_SEGURADO = :MTIPO-SEGURADO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_ITEM
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_CERTIFICADO = '{this.MNUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '{this.MTIPO_SEGURADO}'";

            return query;
        }
        public string SNUM_ITEM { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string MTIPO_SEGURADO { get; set; }

        public static M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1 Execute(M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1 m_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1)
        {
            var ths = m_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.SNUM_ITEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}