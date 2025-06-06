using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0600B
{
    public class R77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1_Insert1 : QueryBasis<R77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_RETENCAO_PROPOSTA
            ( NUM_CERTIFICADO
            , NUM_CPF
            , COD_IDE_CONSULTA
            , IND_SERV_CONSULTA
            , IND_PROCESSAMENTO
            , IND_ACEITACAO
            , COD_USUARIO
            , DTH_GERACAO
            , DTH_PROCESSAMENTO
            , DTH_CONSUMO
            , IND_RET_SUBSCRICAO
            , PCT_AGRAVO
            , VLR_PRM_SEM_AGR
            )
            VALUES
            ( :GE406-NUM-CERTIFICADO
            , :GE406-NUM-CPF
            , :GE406-COD-IDE-CONSULTA
            , :GE406-IND-SERV-CONSULTA
            , :GE406-IND-PROCESSAMENTO
            , NULL
            , :GE406-COD-USUARIO
            , CURRENT TIMESTAMP
            , NULL
            , NULL
            , :GE406-IND-RET-SUBSCRICAO
            , :GE406-PCT-AGRAVO
            , :GE406-VLR-PRM-SEM-AGR
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_RETENCAO_PROPOSTA ( NUM_CERTIFICADO , NUM_CPF , COD_IDE_CONSULTA , IND_SERV_CONSULTA , IND_PROCESSAMENTO , IND_ACEITACAO , COD_USUARIO , DTH_GERACAO , DTH_PROCESSAMENTO , DTH_CONSUMO , IND_RET_SUBSCRICAO , PCT_AGRAVO , VLR_PRM_SEM_AGR ) VALUES ( {FieldThreatment(this.GE406_NUM_CERTIFICADO)} , {FieldThreatment(this.GE406_NUM_CPF)} , {FieldThreatment(this.GE406_COD_IDE_CONSULTA)} , {FieldThreatment(this.GE406_IND_SERV_CONSULTA)} , {FieldThreatment(this.GE406_IND_PROCESSAMENTO)} , NULL , {FieldThreatment(this.GE406_COD_USUARIO)} , CURRENT TIMESTAMP , NULL , NULL , {FieldThreatment(this.GE406_IND_RET_SUBSCRICAO)} , {FieldThreatment(this.GE406_PCT_AGRAVO)} , {FieldThreatment(this.GE406_VLR_PRM_SEM_AGR)} )";

            return query;
        }
        public string GE406_NUM_CERTIFICADO { get; set; }
        public string GE406_NUM_CPF { get; set; }
        public string GE406_COD_IDE_CONSULTA { get; set; }
        public string GE406_IND_SERV_CONSULTA { get; set; }
        public string GE406_IND_PROCESSAMENTO { get; set; }
        public string GE406_COD_USUARIO { get; set; }
        public string GE406_IND_RET_SUBSCRICAO { get; set; }
        public string GE406_PCT_AGRAVO { get; set; }
        public string GE406_VLR_PRM_SEM_AGR { get; set; }

        public static void Execute(R77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1_Insert1 r77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1_Insert1)
        {
            var ths = r77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}