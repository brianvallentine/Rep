using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1 : QueryBasis<R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0COMISSAO_FENAE
				SET AGECOBR =  '{this.V0COFE_AGECOBR}' ,
				NUM_MATRICULA =  '{this.V0COFE_NUM_MATR}' ,
				COD_AGENCIA_DEB =  '{this.V0COFE_AGENCIA_DEB}' ,
				OPERACAO_DEB =  '{this.V0COFE_OPERACAO_DEB}' ,
				NUM_CONTA_DEB =  '{this.V0COFE_NUMCTA_DEB}' ,
				DIG_CONTA_DEB =  '{this.V0COFE_DIGCTA_DEB}' ,
				NOM_SINDICO =  '{this.V0COFE_NOME_SIND}' ,
				SITUACAO =  '{this.V0COFE_SITUACAO}' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUMBIL =  '{this.V0COFE_NUMBIL}'";

            return query;
        }
        public string V0COFE_OPERACAO_DEB { get; set; }
        public string V0COFE_AGENCIA_DEB { get; set; }
        public string V0COFE_NUMCTA_DEB { get; set; }
        public string V0COFE_DIGCTA_DEB { get; set; }
        public string V0COFE_NOME_SIND { get; set; }
        public string V0COFE_NUM_MATR { get; set; }
        public string V0COFE_SITUACAO { get; set; }
        public string V0COFE_AGECOBR { get; set; }
        public string V0COFE_NUMBIL { get; set; }

        public static void Execute(R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1 r3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1)
        {
            var ths = r3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}