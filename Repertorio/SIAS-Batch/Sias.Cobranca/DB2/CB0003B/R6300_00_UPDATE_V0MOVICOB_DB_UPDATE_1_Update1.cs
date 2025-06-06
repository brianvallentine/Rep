using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 : QueryBasis<R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0MOVICOB
				SET SITUACAO =  '{this.W1MCOB_SITUACAO}',
				NOME =  '{this.W1MCOB_NOME}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  BANCO =  '{this.V1MCOB_BANCO}'
				AND AGENCIA =  '{this.V1MCOB_AGENCIA}'
				AND NRAVISO =  '{this.V1MCOB_NRAVISO}'
				AND NRTIT =  '{this.V0MCOB_NRTIT}'
				AND NUM_APOLICE =  '{this.V1MCOB_NUM_APOL}'
				AND NRENDOS =  '{this.V1MCOB_NRENDOS}'
				AND NRPARCEL =  '{this.V1MCOB_NRPARCEL}'";

            return query;
        }
        public string W1MCOB_SITUACAO { get; set; }
        public string W1MCOB_NOME { get; set; }
        public string V1MCOB_NUM_APOL { get; set; }
        public string V1MCOB_NRPARCEL { get; set; }
        public string V1MCOB_AGENCIA { get; set; }
        public string V1MCOB_NRAVISO { get; set; }
        public string V1MCOB_NRENDOS { get; set; }
        public string V1MCOB_BANCO { get; set; }
        public string V0MCOB_NRTIT { get; set; }

        public static void Execute(R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 r6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1)
        {
            var ths = r6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}