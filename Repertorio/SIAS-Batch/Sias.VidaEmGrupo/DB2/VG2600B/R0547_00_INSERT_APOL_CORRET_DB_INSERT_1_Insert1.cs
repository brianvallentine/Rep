using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0547_00_INSERT_APOL_CORRET_DB_INSERT_1_Insert1 : QueryBasis<R0547_00_INSERT_APOL_CORRET_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.APOLICE_CORRETOR
            VALUES (:APOLICOR-NUM-APOLICE ,
            :APOLICOR-RAMO-COBERTURA ,
            :APOLICOR-MODALI-COBERTURA ,
            :APOLICOR-COD-CORRETOR ,
            :APOLICOR-COD-SUBGRUPO ,
            :APOLICOR-DATA-INIVIGENCIA ,
            :APOLICOR-DATA-TERVIGENCIA ,
            :APOLICOR-PCT-PART-CORRETOR,
            :APOLICOR-PCT-COM-CORRETOR ,
            :APOLICOR-TIPO-COMISSAO ,
            :APOLICOR-IND-CORRETOR-PRIN,
            NULL ,
            CURRENT_TIMESTAMP ,
            :APOLICOR-COD-USUARIO )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.APOLICE_CORRETOR VALUES ({FieldThreatment(this.APOLICOR_NUM_APOLICE)} , {FieldThreatment(this.APOLICOR_RAMO_COBERTURA)} , {FieldThreatment(this.APOLICOR_MODALI_COBERTURA)} , {FieldThreatment(this.APOLICOR_COD_CORRETOR)} , {FieldThreatment(this.APOLICOR_COD_SUBGRUPO)} , {FieldThreatment(this.APOLICOR_DATA_INIVIGENCIA)} , {FieldThreatment(this.APOLICOR_DATA_TERVIGENCIA)} , {FieldThreatment(this.APOLICOR_PCT_PART_CORRETOR)}, {FieldThreatment(this.APOLICOR_PCT_COM_CORRETOR)} , {FieldThreatment(this.APOLICOR_TIPO_COMISSAO)} , {FieldThreatment(this.APOLICOR_IND_CORRETOR_PRIN)}, NULL , CURRENT_TIMESTAMP , {FieldThreatment(this.APOLICOR_COD_USUARIO)} )";

            return query;
        }
        public string APOLICOR_NUM_APOLICE { get; set; }
        public string APOLICOR_RAMO_COBERTURA { get; set; }
        public string APOLICOR_MODALI_COBERTURA { get; set; }
        public string APOLICOR_COD_CORRETOR { get; set; }
        public string APOLICOR_COD_SUBGRUPO { get; set; }
        public string APOLICOR_DATA_INIVIGENCIA { get; set; }
        public string APOLICOR_DATA_TERVIGENCIA { get; set; }
        public string APOLICOR_PCT_PART_CORRETOR { get; set; }
        public string APOLICOR_PCT_COM_CORRETOR { get; set; }
        public string APOLICOR_TIPO_COMISSAO { get; set; }
        public string APOLICOR_IND_CORRETOR_PRIN { get; set; }
        public string APOLICOR_COD_USUARIO { get; set; }

        public static void Execute(R0547_00_INSERT_APOL_CORRET_DB_INSERT_1_Insert1 r0547_00_INSERT_APOL_CORRET_DB_INSERT_1_Insert1)
        {
            var ths = r0547_00_INSERT_APOL_CORRET_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0547_00_INSERT_APOL_CORRET_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}