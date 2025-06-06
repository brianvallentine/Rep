using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0077B
{
    public class R1000_00_SELECT_SX010_DB_SELECT_1_Query1 : QueryBasis<R1000_00_SELECT_SX010_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT
            VALUE (A.NUM_APOLICE,+0),
            A.DTA_APOLICE,
            A.COD_FONTE,
            C.NUM_RAMO,
            C.COD_PRODUTO
            INTO :SX010-NUM-APOLICE,
            :SX010-DTA-APOLICE,
            :SX010-COD-FONTE,
            :SX017-NUM-RAMO,
            :SX017-COD-PRODUTO
            FROM SEGUROS.SX_APOLICE A,
            SEGUROS.SX_ORIGEM_CONTRATO B,
            SEGUROS.SX_PRODUTO C
            WHERE A.NUM_APOLICE = :V1MSIN-NUM-APOL
            AND A.STA_APOLICE = 'A'
            AND B.SEQ_APOLICE = A.SEQ_PROP_APOL
            AND B.STA_ORIGEM_CONTRATO = 'A'
            AND C.COD_PRODUTO = B.COD_PRODUTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DISTINCT
											VALUE (A.NUM_APOLICE
							,+0)
							,
											A.DTA_APOLICE
							,
											A.COD_FONTE
							,
											C.NUM_RAMO
							,
											C.COD_PRODUTO
											FROM SEGUROS.SX_APOLICE A
							,
											SEGUROS.SX_ORIGEM_CONTRATO B
							,
											SEGUROS.SX_PRODUTO C
											WHERE A.NUM_APOLICE = '{this.V1MSIN_NUM_APOL}'
											AND A.STA_APOLICE = 'A'
											AND B.SEQ_APOLICE = A.SEQ_PROP_APOL
											AND B.STA_ORIGEM_CONTRATO = 'A'
											AND C.COD_PRODUTO = B.COD_PRODUTO
											WITH UR";

            return query;
        }
        public string SX010_NUM_APOLICE { get; set; }
        public string SX010_DTA_APOLICE { get; set; }
        public string SX010_COD_FONTE { get; set; }
        public string SX017_NUM_RAMO { get; set; }
        public string SX017_COD_PRODUTO { get; set; }
        public string V1MSIN_NUM_APOL { get; set; }

        public static R1000_00_SELECT_SX010_DB_SELECT_1_Query1 Execute(R1000_00_SELECT_SX010_DB_SELECT_1_Query1 r1000_00_SELECT_SX010_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_SELECT_SX010_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_SELECT_SX010_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_SELECT_SX010_DB_SELECT_1_Query1();
            var i = 0;
            dta.SX010_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SX010_DTA_APOLICE = result[i++].Value?.ToString();
            dta.SX010_COD_FONTE = result[i++].Value?.ToString();
            dta.SX017_NUM_RAMO = result[i++].Value?.ToString();
            dta.SX017_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}