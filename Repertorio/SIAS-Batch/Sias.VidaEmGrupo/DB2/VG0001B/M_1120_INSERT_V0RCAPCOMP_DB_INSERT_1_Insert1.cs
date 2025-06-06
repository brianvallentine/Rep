using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 : QueryBasis<M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.RCAP_COMPLEMENTAR
            (COD_FONTE ,
            NUM_RCAP ,
            NUM_RCAP_COMPLEMEN ,
            COD_OPERACAO ,
            DATA_MOVIMENTO ,
            HORA_OPERACAO ,
            SIT_REGISTRO ,
            BCO_AVISO ,
            AGE_AVISO ,
            NUM_AVISO_CREDITO ,
            VAL_RCAP ,
            DATA_RCAP ,
            DATA_CADASTRAMENTO ,
            SIT_CONTABIL ,
            COD_EMPRESA ,
            TIMESTAMP )
            VALUES (:RCAPCOMP-COD-FONTE ,
            :RCAPCOMP-NUM-RCAP ,
            :RCAPCOMP-NUM-RCAP-COMPLEMEN,
            :RCAPCOMP-COD-OPERACAO ,
            :SISTEMAS-DATA-MOV-ABERTO ,
            CURRENT TIME ,
            :RCAPCOMP-SIT-REGISTRO ,
            :RCAPCOMP-BCO-AVISO ,
            :RCAPCOMP-AGE-AVISO ,
            :RCAPCOMP-NUM-AVISO-CREDITO ,
            :RCAPCOMP-VAL-RCAP ,
            :RCAPCOMP-DATA-RCAP ,
            :RCAPCOMP-DATA-CADASTRAMENTO,
            :RCAPCOMP-SIT-CONTABIL ,
            :RCAPCOMP-COD-EMPRESA ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RCAP_COMPLEMENTAR (COD_FONTE , NUM_RCAP , NUM_RCAP_COMPLEMEN , COD_OPERACAO , DATA_MOVIMENTO , HORA_OPERACAO , SIT_REGISTRO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , VAL_RCAP , DATA_RCAP , DATA_CADASTRAMENTO , SIT_CONTABIL , COD_EMPRESA , TIMESTAMP ) VALUES ({FieldThreatment(this.RCAPCOMP_COD_FONTE)} , {FieldThreatment(this.RCAPCOMP_NUM_RCAP)} , {FieldThreatment(this.RCAPCOMP_NUM_RCAP_COMPLEMEN)}, {FieldThreatment(this.RCAPCOMP_COD_OPERACAO)} , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , CURRENT TIME , {FieldThreatment(this.RCAPCOMP_SIT_REGISTRO)} , {FieldThreatment(this.RCAPCOMP_BCO_AVISO)} , {FieldThreatment(this.RCAPCOMP_AGE_AVISO)} , {FieldThreatment(this.RCAPCOMP_NUM_AVISO_CREDITO)} , {FieldThreatment(this.RCAPCOMP_VAL_RCAP)} , {FieldThreatment(this.RCAPCOMP_DATA_RCAP)} , {FieldThreatment(this.RCAPCOMP_DATA_CADASTRAMENTO)}, {FieldThreatment(this.RCAPCOMP_SIT_CONTABIL)} , {FieldThreatment(this.RCAPCOMP_COD_EMPRESA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string RCAPCOMP_COD_FONTE { get; set; }
        public string RCAPCOMP_NUM_RCAP { get; set; }
        public string RCAPCOMP_NUM_RCAP_COMPLEMEN { get; set; }
        public string RCAPCOMP_COD_OPERACAO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string RCAPCOMP_SIT_REGISTRO { get; set; }
        public string RCAPCOMP_BCO_AVISO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string RCAPCOMP_VAL_RCAP { get; set; }
        public string RCAPCOMP_DATA_RCAP { get; set; }
        public string RCAPCOMP_DATA_CADASTRAMENTO { get; set; }
        public string RCAPCOMP_SIT_CONTABIL { get; set; }
        public string RCAPCOMP_COD_EMPRESA { get; set; }

        public static void Execute(M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 m_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1)
        {
            var ths = m_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}