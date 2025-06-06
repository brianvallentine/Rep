using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1476B
{
    public class R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.DATA_TERVIGENCIA ,
            A.COD_PRODUTO ,
            C.NOME_RAZAO
            INTO :ENDOSSOS-DATA-TERVIGENCIA,
            :ENDOSSOS-COD-PRODUTO,
            :WHOST-NOME-ESTIP
            FROM SEGUROS.ENDOSSOS A,
            SEGUROS.APOLICES B,
            SEGUROS.CLIENTES C
            WHERE A.NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND A.NUM_ENDOSSO = 0
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND C.COD_CLIENTE = B.COD_CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.DATA_TERVIGENCIA 
							,
											A.COD_PRODUTO 
							,
											C.NOME_RAZAO
											FROM SEGUROS.ENDOSSOS A
							,
											SEGUROS.APOLICES B
							,
											SEGUROS.CLIENTES C
											WHERE A.NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = 0
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND C.COD_CLIENTE = B.COD_CLIENTE
											WITH UR";

            return query;
        }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string WHOST_NOME_ESTIP { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1 r1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.WHOST_NOME_ESTIP = result[i++].Value?.ToString();
            return dta;
        }

    }
}