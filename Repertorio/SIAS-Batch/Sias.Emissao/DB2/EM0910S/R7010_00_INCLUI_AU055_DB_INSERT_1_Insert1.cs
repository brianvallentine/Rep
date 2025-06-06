using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R7010_00_INCLUI_AU055_DB_INSERT_1_Insert1 : QueryBasis<R7010_00_INCLUI_AU055_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.AU_HIS_PROP_CONV
            ( NUM_PROPOSTA_VC ,
            SEQ_HISTORICO ,
            NOM_PROGRAMA ,
            DTH_OPERACAO ,
            IND_OPERACAO ,
            DTH_MOVTO_ARQUIVO ,
            NUM_ARQUIVO ,
            STA_ERRO ,
            DTH_CADASTRAMENTO,
            COD_CONGENERE)
            VALUES (:AU055-NUM-PROPOSTA-VC ,
            :AU055-SEQ-HISTORICO ,
            :AU055-NOM-PROGRAMA ,
            :AU055-DTH-OPERACAO ,
            :AU055-IND-OPERACAO ,
            :AU055-DTH-MOVTO-ARQUIVO,
            :AU055-NUM-ARQUIVO ,
            :AU055-STA-ERRO ,
            CURRENT TIMESTAMP,
            :AU055-COD-CONGENERE)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.AU_HIS_PROP_CONV ( NUM_PROPOSTA_VC , SEQ_HISTORICO , NOM_PROGRAMA , DTH_OPERACAO , IND_OPERACAO , DTH_MOVTO_ARQUIVO , NUM_ARQUIVO , STA_ERRO , DTH_CADASTRAMENTO, COD_CONGENERE) VALUES ({FieldThreatment(this.AU055_NUM_PROPOSTA_VC)} , {FieldThreatment(this.AU055_SEQ_HISTORICO)} , {FieldThreatment(this.AU055_NOM_PROGRAMA)} , {FieldThreatment(this.AU055_DTH_OPERACAO)} , {FieldThreatment(this.AU055_IND_OPERACAO)} , {FieldThreatment(this.AU055_DTH_MOVTO_ARQUIVO)}, {FieldThreatment(this.AU055_NUM_ARQUIVO)} , {FieldThreatment(this.AU055_STA_ERRO)} , CURRENT TIMESTAMP, {FieldThreatment(this.AU055_COD_CONGENERE)})";

            return query;
        }
        public string AU055_NUM_PROPOSTA_VC { get; set; }
        public string AU055_SEQ_HISTORICO { get; set; }
        public string AU055_NOM_PROGRAMA { get; set; }
        public string AU055_DTH_OPERACAO { get; set; }
        public string AU055_IND_OPERACAO { get; set; }
        public string AU055_DTH_MOVTO_ARQUIVO { get; set; }
        public string AU055_NUM_ARQUIVO { get; set; }
        public string AU055_STA_ERRO { get; set; }
        public string AU055_COD_CONGENERE { get; set; }

        public static void Execute(R7010_00_INCLUI_AU055_DB_INSERT_1_Insert1 r7010_00_INCLUI_AU055_DB_INSERT_1_Insert1)
        {
            var ths = r7010_00_INCLUI_AU055_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7010_00_INCLUI_AU055_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}