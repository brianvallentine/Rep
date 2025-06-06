using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R0005_00_UPDATE_ESTOQUE_DB_UPDATE_1_Update1 : QueryBasis<R0005_00_UPDATE_ESTOQUE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.OPCAO_PAG_VIDAZUL C SET
				OPCAO_PAGAMENTO = '1'
				WHERE  C.OPCAO_PAGAMENTO = '3'
				AND C.DATA_TERVIGENCIA = '9999-12-31'
				AND C.OPE_CONTA_DEBITO = 1
				AND (C.COD_AGENCIA_DEBITO IS NOT NULL
				OR
				C.COD_AGENCIA_DEBITO <> 0)
				AND (C. NUM_CONTA_DEBITO IS NOT NULL
				OR
				C. NUM_CONTA_DEBITO <> 0)
				AND (C.DIG_CONTA_DEBITO IS NOT NULL
				OR
				C.DIG_CONTA_DEBITO <> 0)
				AND C.NUM_CERTIFICADO IN
				(SELECT B.NUM_CERTIFICADO
				FROM SEGUROS.APOLICES A
				, SEGUROS.SEGURADOS_VGAP B
				WHERE  A.NUM_APOLICE IN ( 0109300002005
				, 0109300002008
				, 109300002741 )
				AND A.COD_PRODUTO = 9328
				AND B.NUM_APOLICE = A.NUM_APOLICE )";

            return query;
        }

        public static void Execute(R0005_00_UPDATE_ESTOQUE_DB_UPDATE_1_Update1 r0005_00_UPDATE_ESTOQUE_DB_UPDATE_1_Update1)
        {
            var ths = r0005_00_UPDATE_ESTOQUE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0005_00_UPDATE_ESTOQUE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}