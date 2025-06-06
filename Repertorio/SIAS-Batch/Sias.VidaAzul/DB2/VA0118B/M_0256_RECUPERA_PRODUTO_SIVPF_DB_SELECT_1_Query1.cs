using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1 : QueryBasis<M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO_SIVPF
            INTO :PROPOFID-COD-PRODUTO-SIVPF
            FROM SEGUROS.PRODUTOS_SIVPF
            WHERE COD_PRODUTO = :PROPVA-CODPRODU
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO_SIVPF
											FROM SEGUROS.PRODUTOS_SIVPF
											WHERE COD_PRODUTO = '{this.PROPVA_CODPRODU}'
											WITH UR";

            return query;
        }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPVA_CODPRODU { get; set; }

        public static M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1 Execute(M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1 m_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1)
        {
            var ths = m_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}