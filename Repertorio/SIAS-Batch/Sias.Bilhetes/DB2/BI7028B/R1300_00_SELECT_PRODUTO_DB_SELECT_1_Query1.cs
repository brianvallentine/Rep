using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class R1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_PRODUTO,
            NUM_PROCESSO_SUSEP
            , COD_EMPRESA
            INTO :PRODUTO-DESCR-PRODUTO,
            :PRODUTO-NUM-PROCESSO-SUSEP:VIND-NULL-SUSEP
            , :PRODUTO-COD-EMPRESA
            FROM SEGUROS.PRODUTO
            WHERE COD_PRODUTO =:PROPOFID-COD-PRODUTO-SIVPF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCR_PRODUTO
							,
											NUM_PROCESSO_SUSEP
											, COD_EMPRESA
											FROM SEGUROS.PRODUTO
											WHERE COD_PRODUTO ='{this.PROPOFID_COD_PRODUTO_SIVPF}'";

            return query;
        }
        public string PRODUTO_DESCR_PRODUTO { get; set; }
        public string PRODUTO_NUM_PROCESSO_SUSEP { get; set; }
        public string VIND_NULL_SUSEP { get; set; }
        public string PRODUTO_COD_EMPRESA { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }

        public static R1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1 r1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTO_DESCR_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUTO_NUM_PROCESSO_SUSEP = result[i++].Value?.ToString();
            dta.VIND_NULL_SUSEP = string.IsNullOrWhiteSpace(dta.PRODUTO_NUM_PROCESSO_SUSEP) ? "-1" : "0";
            dta.PRODUTO_COD_EMPRESA = result[i++].Value?.ToString();
            return dta;
        }

    }
}