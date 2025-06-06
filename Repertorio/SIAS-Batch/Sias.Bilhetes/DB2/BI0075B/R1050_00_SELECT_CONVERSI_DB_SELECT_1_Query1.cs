using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0075B
{
    public class R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1 : QueryBasis<R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_PROPOSTA_SIVPF ,
            A.COD_PRODUTO_SIVPF ,
            B.NUM_SICOB ,
            B.ORIGEM_PROPOSTA
            INTO :V0PRFD-NUMPROPOSTA ,
            :V0PRFD-CODPROD ,
            :V0PRFD-NUMSICOB ,
            :V0PRFD-ORIGEM-PROPOSTA
            FROM SEGUROS.CONVERSAO_SICOB A,
            SEGUROS.PROPOSTA_FIDELIZ B
            WHERE A.NUM_PROPOSTA_SIVPF >= :WSHOST-NUMSIV01
            AND A.NUM_PROPOSTA_SIVPF <= :WSHOST-NUMSIV02
            AND A.NUM_PROPOSTA_SIVPF = B.NUM_PROPOSTA_SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_PROPOSTA_SIVPF 
							,
											A.COD_PRODUTO_SIVPF 
							,
											B.NUM_SICOB 
							,
											B.ORIGEM_PROPOSTA
											FROM SEGUROS.CONVERSAO_SICOB A
							,
											SEGUROS.PROPOSTA_FIDELIZ B
											WHERE A.NUM_PROPOSTA_SIVPF >= '{this.WSHOST_NUMSIV01}'
											AND A.NUM_PROPOSTA_SIVPF <= '{this.WSHOST_NUMSIV02}'
											AND A.NUM_PROPOSTA_SIVPF = B.NUM_PROPOSTA_SIVPF
											WITH UR";

            return query;
        }
        public string V0PRFD_NUMPROPOSTA { get; set; }
        public string V0PRFD_CODPROD { get; set; }
        public string V0PRFD_NUMSICOB { get; set; }
        public string V0PRFD_ORIGEM_PROPOSTA { get; set; }
        public string WSHOST_NUMSIV01 { get; set; }
        public string WSHOST_NUMSIV02 { get; set; }

        public static R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1 Execute(R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1 r1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PRFD_NUMPROPOSTA = result[i++].Value?.ToString();
            dta.V0PRFD_CODPROD = result[i++].Value?.ToString();
            dta.V0PRFD_NUMSICOB = result[i++].Value?.ToString();
            dta.V0PRFD_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}