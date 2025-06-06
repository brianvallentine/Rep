using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1_Update1 : QueryBasis<B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0RCAPCOMP
				SET SITUACAO = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  FONTE =  '{this.PCOM_FONTE}'
				AND NRRCAP =  '{this.PCOM_NRRCAP}'
				AND NRRCAPCO =  '{this.PCOM_NRRCAPCO}'
				AND OPERACAO =  '{this.PCOM_OPERACAO}'
				AND DTMOVTO =  '{this.PCOM_DTMOVTO}'
				AND HORAOPER =  '{this.PCOM_HORAOPER}'";

            return query;
        }
        public string PCOM_NRRCAPCO { get; set; }
        public string PCOM_OPERACAO { get; set; }
        public string PCOM_HORAOPER { get; set; }
        public string PCOM_DTMOVTO { get; set; }
        public string PCOM_NRRCAP { get; set; }
        public string PCOM_FONTE { get; set; }

        public static void Execute(B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1_Update1 b2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1_Update1)
        {
            var ths = b2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}